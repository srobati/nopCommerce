﻿using Microsoft.AspNetCore.Html;

namespace Nop.Web.Framework.UI
{
    /// <summary>
    /// Represents a HTML helper
    /// </summary>
    public partial interface INopHtmlHelper
    {
        /// <summary>
        /// Add title element to the <![CDATA[<head>]]>
        /// </summary>
        /// <param name="part">Title part</param>
        void AddTitleParts(string part);

        /// <summary>
        /// Append title element to the <![CDATA[<head>]]>
        /// </summary>
        /// <param name="part">Title part</param>
        void AppendTitleParts(string part);

        /// <summary>
        /// Generate all title parts
        /// </summary>
        /// <param name="addDefaultTitle">A value indicating whether to insert a default title</param>
        /// <param name="part">Title part</param>
        /// <returns>Generated HTML string</returns>
        IHtmlContent GenerateTitle(bool addDefaultTitle = true, string part = "");

        /// <summary>
        /// Add meta description element to the <![CDATA[<head>]]>
        /// </summary>
        /// <param name="part">Meta description part</param>
        void AddMetaDescriptionParts(string part);

        /// <summary>
        /// Append meta description element to the <![CDATA[<head>]]>
        /// </summary>
        /// <param name="part">Meta description part</param>
        void AppendMetaDescriptionParts(string part);

        /// <summary>
        /// Generate all description parts
        /// </summary>
        /// <param name="part">Meta description part</param>
        /// <returns>Generated HTML string</returns>
        IHtmlContent GenerateMetaDescription(string part = "");

        /// <summary>
        /// Add meta keyword element to the <![CDATA[<head>]]>
        /// </summary>
        /// <param name="part">Meta keyword part</param>
        void AddMetaKeywordParts(string part);

        /// <summary>
        /// Append meta keyword element to the <![CDATA[<head>]]>
        /// </summary>
        /// <param name="part">Meta keyword part</param>
        void AppendMetaKeywordParts(string part);

        /// <summary>
        /// Generate all keyword parts
        /// </summary>
        /// <param name="part">Meta keyword part</param>
        /// <returns>Generated HTML string</returns>
        IHtmlContent GenerateMetaKeywords(string part = "");

        /// <summary>
        /// Add script element
        /// </summary>
        /// <param name="location">A location of the script element</param>
        /// <param name="src">Script path (minified version)</param>
        /// <param name="debugSrc">Script path (full debug version). If empty, then minified version will be used</param>
        /// <param name="isAsync">A value indicating whether to add an attribute "async" or not for js files</param>
        void AddScriptParts(ResourceLocation location, string src, string debugSrc = "", bool isAsync = false);

        /// <summary>
        /// Append script element
        /// </summary>
        /// <param name="location">A location of the script element</param>
        /// <param name="src">Script path (minified version)</param>
        /// <param name="debugSrc">Script path (full debug version). If empty, then minified version will be used</param>
        /// <param name="isAsync">A value indicating whether to add an attribute "async" or not for js files</param>
        void AppendScriptParts(ResourceLocation location, string src, string debugSrc = "", bool isAsync = false);

        /// <summary>
        /// Generate all script parts
        /// </summary>
        /// <param name="location">A location of the script element</param>
        /// <returns>Generated HTML string</returns>
        IHtmlContent GenerateScripts(ResourceLocation location);

        /// <summary>
        /// Add inline script element
        /// </summary>
        /// <param name="location">A location of the script element</param>
        /// <param name="script">Script</param>
        void AddInlineScriptParts(ResourceLocation location, string script);

        /// <summary>
        /// Append inline script element
        /// </summary>
        /// <param name="location">A location of the script element</param>
        /// <param name="script">Script</param>
        void AppendInlineScriptParts(ResourceLocation location, string script);

        /// <summary>
        /// Generate all inline script parts
        /// </summary>
        /// <param name="location">A location of the script element</param>
        /// <returns>Generated HTML string</returns>
        IHtmlContent GenerateInlineScripts(ResourceLocation location);

        /// <summary>
        /// Add CSS element
        /// </summary>
        /// <param name="location">A location of the script element</param>
        /// <param name="src">Script path (minified version)</param>
        /// <param name="debugSrc">Script path (full debug version). If empty, then minified version will be used</param>
        void AddCssFileParts(ResourceLocation location, string src, string debugSrc);

        /// <summary>
        /// Append CSS element
        /// </summary>
        /// <param name="location">A location of the script element</param>
        /// <param name="src">Script path (minified version)</param>
        /// <param name="debugSrc">Script path (full debug version). If empty, then minified version will be used</param>
        void AppendCssFileParts(ResourceLocation location, string src, string debugSrc);

        /// <summary>
        /// Generate all CSS parts
        /// </summary>
        /// <param name="location">A location of the script element</param>
        /// <returns>Generated HTML string</returns>
        IHtmlContent GenerateCssFiles(ResourceLocation location);

        /// <summary>
        /// Add canonical URL element to the <![CDATA[<head>]]>
        /// </summary>
        /// <param name="part">Canonical URL part</param>
        /// <param name="withQueryString">Whether to use canonical URLs with query string parameters</param>
        void AddCanonicalUrlParts(string part, bool withQueryString = false);

        /// <summary>
        /// Append canonical URL element to the <![CDATA[<head>]]>
        /// </summary>
        /// <param name="part">Canonical URL part</param>
        void AppendCanonicalUrlParts(string part);

        /// <summary>
        /// Generate all canonical URL parts
        /// </summary>
        /// <returns>Generated HTML string</returns>
        IHtmlContent GenerateCanonicalUrls();

        /// <summary>
        /// Add any custom element to the <![CDATA[<head>]]> element
        /// </summary>
        /// <param name="part">The entire element. For example, <![CDATA[<meta name="msvalidate.01" content="123121231231313123123" />]]></param>
        void AddHeadCustomParts(string part);

        /// <summary>
        /// Append any custom element to the <![CDATA[<head>]]> element
        /// </summary>
        /// <param name="part">The entire element. For example, <![CDATA[<meta name="msvalidate.01" content="123121231231313123123" />]]></param>
        void AppendHeadCustomParts(string part);

        /// <summary>
        /// Generate all custom elements
        /// </summary>
        /// <returns>Generated HTML string</returns>
        IHtmlContent GenerateHeadCustom();

        /// <summary>
        /// Add CSS class to the <![CDATA[<head>]]> element
        /// </summary>
        /// <param name="part">CSS class</param>
        void AddPageCssClassParts(string part);

        /// <summary>
        /// Append CSS class to the <![CDATA[<head>]]> element
        /// </summary>
        /// <param name="part">CSS class</param>
        void AppendPageCssClassParts(string part);

        /// <summary>
        /// Generate all title parts
        /// </summary>
        /// <param name="part">CSS class</param>
        /// <returns>Generated string</returns>
        string GeneratePageCssClasses(string part = "");

        /// <summary>
        /// Specify "edit page" URL
        /// </summary>
        /// <param name="url">URL</param>
        void AddEditPageUrl(string url);

        /// <summary>
        /// Get "edit page" URL
        /// </summary>
        /// <returns>URL</returns>
        string GetEditPageUrl();

        /// <summary>
        /// Specify system name of admin menu item that should be selected (expanded)
        /// </summary>
        /// <param name="systemName">System name</param>
        void SetActiveMenuItemSystemName(string systemName);

        /// <summary>
        /// Get system name of admin menu item that should be selected (expanded)
        /// </summary>
        /// <returns>System name</returns>
        string GetActiveMenuItemSystemName();
    }
}