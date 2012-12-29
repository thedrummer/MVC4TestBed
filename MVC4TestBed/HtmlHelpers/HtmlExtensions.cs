using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using MVC4TestBed.Models;
using Web;

namespace MVC4TestBed.HtmlHelpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString ClientIdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                   Expression<Func<TModel, TProperty>> expression)
        {
            return MvcHtmlString.Create(
                htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(
                    ExpressionHelper.GetExpressionText(expression)));
        }

        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            var realModelType = modelMetadata.ModelType;

            var underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }

        private static readonly SelectListItem[] SingleEmptyItem = new[] {new SelectListItem {Text = "", Value = ""}};

        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute), false);

            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper,
                                                                       Expression<Func<TModel, TEnum>> expression)
        {
            return EnumDropDownListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper,
                                                                       Expression<Func<TModel, TEnum>> expression,
                                                                       object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var enumType = GetNonNullableModelType(metadata);
            var values = Enum.GetValues(enumType).Cast<TEnum>();

            var items = from value in values
                        select new SelectListItem
                            {
                                Text = GetEnumDescription(value),
                                Value = value.ToString(),
                                Selected = value.Equals(metadata.Model)
                            };

            // If the enum is nullable, add an 'empty' item to the collection
            if (metadata.IsNullableValueType)
                items = SingleEmptyItem.Concat(items);

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }

        public static string RouteUrl(this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues)
        {
            return UrlHelper.GenerateUrl(
                routeName,
                null /*actionName*/,
                null /*controllerName*/,
                routeValues,
                htmlHelper.RouteCollection,
                htmlHelper.ViewContext.RequestContext,
                true
                );
        }

        public static string RouteUrl(this HtmlHelper htmlHelper, RouteValueDictionary routeValues)
        {
            return RouteUrl(htmlHelper, "Default", new RouteValueDictionary(routeValues));
        }

        //public static MvcHtmlString MyRouteLink(
        //    this HtmlHelper htmlHelper,
        //    string linkText,
        //    string routeName,
        //    RouteValueDictionary routeValues,
        //    IDictionary<string, object> htmlAttributes)
        //{
        //    string url = RouteUrl(htmlHelper, routeName, routeValues);
        //    TagBuilder tagBuilder = new TagBuilder("a")
        //        {
        //            InnerHtml = (!String.IsNullOrEmpty(linkText)) ? linkText : String.Empty
        //        };
        //    tagBuilder.MergeAttributes(htmlAttributes);
        //    tagBuilder.MergeAttribute("href", url);
        //    return MvcHtmlString.Create((tagBuilder.ToString(TagRenderMode.Normal)));
        //}

        //public static MvcHtmlString MyRouteLink(
        //    this HtmlHelper htmlHelper,
        //    string linkText,
        //    string routeName,
        //    RouteValueDictionary routeValues)
        //{
        //    return MyRouteLink(
        //        htmlHelper,
        //        linkText,
        //        routeName,
        //        routeValues,
        //        new RouteValueDictionary()
        //    );
        //}
        //public static MvcHtmlString MyRouteLink(
        //    this HtmlHelper htmlHelper,
        //    string linkText,
        //    string routeName,
        //    object routeValues)
        //{
        //    return MyRouteLink(
        //        htmlHelper,
        //        linkText,
        //        routeName,
        //        new RouteValueDictionary(routeValues)
        //    );
        //} 

    }

    #region Paging

    public class PagingHtmlBuilder
    {
        public string BuildHtmlItem(string url, string display, bool active = false, bool disabled = false)
        {
            // every item wrapped in LI tag
            var liTag = new TagBuilder("li");
            if (disabled)
            {
                // add disabled class and use a SPAN tag inside
                liTag.MergeAttribute("class", "disabled");
                var spanTag = new TagBuilder("span") {InnerHtml = display};
                liTag.InnerHtml = spanTag.ToString();
            }
            else
            {
                if (active)
                {
                    liTag.MergeAttribute("class", "active");
                }
                // use inner A tag
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", url);
                tag.InnerHtml = display;
                liTag.InnerHtml = tag.ToString();
            }
            return liTag.ToString();
        }
    }

    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(
            this HtmlHelper htmlHelper,
            PagingInfo pagingInfo
            )
        {
            var pagingBuilder = new PagingHtmlBuilder();
            var result = new StringBuilder();

            //previous link
            var url = BuildPageUrl(htmlHelper, (pagingInfo.CurrentPage - 1));
            var prevLink = (pagingInfo.CurrentPage == 1)
                               ? pagingBuilder.BuildHtmlItem(url, "Prev", false, true)
                               : pagingBuilder.BuildHtmlItem(url, "Prev");
            result.Append(prevLink);

            // only show up to 5 links to the left of the current page
            var start = (pagingInfo.CurrentPage <= 6) ? 1 : (pagingInfo.CurrentPage - 5);
            // only show up to 5 links to the right of the current page
            var end = (pagingInfo.CurrentPage > (pagingInfo.TotalPages - 5))
                          ? pagingInfo.TotalPages
                          : pagingInfo.CurrentPage + 5;

            for (var i = start; i <= end; i++)
            {
                url = BuildPageUrl(htmlHelper, i);
                var pageHtml = (i == pagingInfo.CurrentPage)
                                   ? pagingBuilder.BuildHtmlItem(url, i.ToString(CultureInfo.InvariantCulture), true)
                                   : pagingBuilder.BuildHtmlItem(url, i.ToString(CultureInfo.InvariantCulture));
                result.Append(pageHtml);
            }

            // next link
            url = BuildPageUrl(htmlHelper, (pagingInfo.CurrentPage + 1));
            var nextLink = (pagingInfo.CurrentPage == pagingInfo.TotalPages)
                               ? pagingBuilder.BuildHtmlItem(url, "Next", false, true)
                               : pagingBuilder.BuildHtmlItem(url, "Next");
            result.Append(nextLink);

            return MvcHtmlString.Create(result.ToString());
        }

        public static string BuildPageUrl(this HtmlHelper htmlHelper, int pageNumber)
        {
            var routeData = new RouteValueDictionary { { "CurrentPage", pageNumber } };
            routeData.AddQueryStringParameters();
            return htmlHelper.RouteUrl(routeData);
        }
    }

    #endregion
}