﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BootstrapForms.Utilities;

namespace BootstrapForms.HtmlHelpers
{
    /// <summary>
    /// Represents bootstrap v3 support for HTML input controls
    /// </summary>
    public static class InputExtensions
    {
        #region TextBox
        public static MvcHtmlString BsTextBox(this HtmlHelper helper, string name)
        {
            return BsTextBox(helper, name, value: null);
        }
        public static MvcHtmlString BsTextBox(this HtmlHelper helper, string name, object value)
        {
            return BsTextBox(helper, name, value, format: null);
        }
        public static MvcHtmlString BsTextBox(this HtmlHelper helper, string name, object value, string format)
        {
            return BsTextBox(helper, name, value, format, htmlAttributes: (object)null);
        }
        public static MvcHtmlString BsTextBox(this HtmlHelper helper, string name, object value, object htmlAttributes)
        {
            return BsTextBox(helper, name, value, format: null, htmlAttributes: htmlAttributes);
        }
        public static MvcHtmlString BsTextBox(this HtmlHelper helper, string name, object value, string format, object htmlAttributes)
        {
            return BsTextBox(helper, name, value, format, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        public static MvcHtmlString BsTextBox(this HtmlHelper helper, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            return BsTextBox(helper, name, value, format: null, htmlAttributes: htmlAttributes);
        }
        public static MvcHtmlString BsTextBox(this HtmlHelper helper, string name, object value, string format, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromStringExpression(name, helper.ViewContext.ViewData);
            if (value != null)
            {
                metadata.Model = value;
            }

            //add placeholder           
            if (!string.IsNullOrEmpty(metadata.Watermark) && !htmlAttributes.ContainsKey("placeholder"))
            {
                htmlAttributes.MergeAttribute("placeholder", metadata.Watermark);
            }

            //add html5 input type
            if (!string.IsNullOrEmpty(metadata.DataTypeName))
            {
                htmlAttributes.MergeAttribute("type", metadata.DataTypeName.GetHtml5Type());
            }

            //merge custom css classes with bootstrap
            htmlAttributes.MergeAttribute("class", "form-control");
            return helper.TextBox(name, value, format, htmlAttributes);

        }

        public static MvcHtmlString BsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return BsTextBoxFor(helper, expression, (object)null);
        }

        public static MvcHtmlString BsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return BsTextBoxFor(helper, expression, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Returns a textbox input element with placeholder and info tooltip
        /// </summary>
        public static MvcHtmlString BsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var fieldName = ExpressionHelper.GetExpressionText(expression);
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? fieldName.Split('.').Last();

            var model = typeof(TModel);
            var property = model.GetProperty(fieldName);

            //merge custom css classes with bootstrap
            htmlAttributes.MergeAttribute("class", "form-control");

            //add placeholder           
            if (!string.IsNullOrEmpty(metadata.Watermark) && !htmlAttributes.ContainsKey("placeholder"))
            {
                htmlAttributes.MergeAttribute("placeholder", metadata.Watermark);
            }

            //add html5 input types
            if (!string.IsNullOrEmpty(metadata.DataTypeName))
            {
                htmlAttributes.MergeAttribute("type", metadata.DataTypeName.GetHtml5Type());
            }

            //add info tooltip
            var description = new MvcHtmlString("");
            if (!string.IsNullOrEmpty(metadata.Description))
            {
                description = helper.BsDescriptionFor(expression);
            }

            return MvcHtmlString.Create(helper.TextBoxFor(expression, htmlAttributes).ToHtmlString() + description.ToHtmlString());
        }

        #endregion

        #region TextArea
        public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name)
        {
            return BsTextArea(htmlHelper, name, null /* value */, null /* htmlAttributes */);
        }

        public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return BsTextArea(htmlHelper, name, null /* value */, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
        {
            return BsTextArea(htmlHelper, name, null /* value */, htmlAttributes);
        }

        public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, string value)
        {
            return BsTextArea(htmlHelper, name, value, null /* htmlAttributes */);
        }

        public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, string value, object htmlAttributes)
        {
            return BsTextArea(htmlHelper, name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, string value, IDictionary<string, object> htmlAttributes)
        {
            return BsTextArea(htmlHelper, name, value, 2, 20, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, object htmlAttributes)
        {
            return BsTextArea(htmlHelper, name, value, rows, columns, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString BsTextArea(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromStringExpression(name, htmlHelper.ViewContext.ViewData);
            if (value != null)
            {
                metadata.Model = value;
            }

            //add placeholder           
            if (!string.IsNullOrEmpty(metadata.Watermark) && !htmlAttributes.ContainsKey("placeholder"))
            {
                htmlAttributes.MergeAttribute("placeholder", metadata.Watermark);
            }

            //add html5 input type
            if (!string.IsNullOrEmpty(metadata.DataTypeName))
            {
                htmlAttributes.MergeAttribute("type", metadata.DataTypeName.GetHtml5Type());
            }

            //merge custom css classes with bootstrap
            htmlAttributes.MergeAttribute("class", "form-control");
            return htmlHelper.TextArea(name, value, rows, columns, htmlAttributes);
        }

        /// <summary>
        /// Returns a textbox area element with placeholder and info tooltip
        /// </summary>
        public static MvcHtmlString BsTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            //merge custom css classes with bootstrap
            htmlAttributes.MergeAttribute("class", "form-control");

            //add placeholder
            if (!string.IsNullOrEmpty(metadata.Watermark) && !htmlAttributes.ContainsKey("placeholder"))
            {
                htmlAttributes.MergeAttribute("placeholder", metadata.Watermark);
            }

            //add info tooltip
            var description = new MvcHtmlString("");
            if (!string.IsNullOrEmpty(metadata.Description))
            {
                description = helper.BsDescriptionFor(expression);
            }

            return MvcHtmlString.Create(helper.TextAreaFor(expression, htmlAttributes).ToHtmlString() + description.ToHtmlString());
        }
        public static MvcHtmlString BsTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return BsTextAreaFor(helper, expression, (object)null);
        }
        public static MvcHtmlString BsTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return BsTextAreaFor(helper, expression, new RouteValueDictionary(htmlAttributes));
        }

        #endregion

        #region CheckBox

        /// <summary>
        /// Returns a checkbox input element wrapped in a label element
        /// </summary>
        public static MvcHtmlString BsCheckBox(this HtmlHelper htmlHelper, string name)
        {
            return BsCheckBox(htmlHelper, name, htmlAttributes: (object)null);
        }

        /// <summary>
        /// Returns a checkbox input element wrapped in a label element
        /// </summary>
        public static MvcHtmlString BsCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked)
        {
            return BsCheckBox(htmlHelper, name, isChecked, htmlAttributes: (object)null);
        }

        /// <summary>
        /// Returns a checkbox input element wrapped in a label element
        /// </summary>
        public static MvcHtmlString BsCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked, object htmlAttributes)
        {
            return BsCheckBox(htmlHelper, name, isChecked, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns a checkbox input element wrapped in a label element
        /// </summary>
        public static MvcHtmlString BsCheckBox(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return BsCheckBox(htmlHelper, name, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Returns a checkbox input element wrapped in a label element
        /// </summary>
        public static MvcHtmlString BsCheckBox(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
        {
            return BsCheckBox(htmlHelper, name: name, isChecked: false, htmlAttributes: htmlAttributes);
        }

        /// <summary>
        /// Returns a checkbox input element wrapped in a label element
        /// </summary>
        public static MvcHtmlString BsCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromStringExpression(name, htmlHelper.ViewData);
            var fieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? fieldName.Split('.').Last();

            var labelTag = new TagBuilder("label");
            var labelHtml = new StringBuilder(labelTag.ToString(TagRenderMode.StartTag));
            labelHtml.Append(htmlHelper.CheckBox(name, isChecked, htmlAttributes));
            labelHtml.AppendLine(labelText);
            labelHtml.AppendLine(labelTag.ToString(TagRenderMode.EndTag));

            return MvcHtmlString.Create(labelHtml.ToString());
        }

        /// <summary>
        /// Returns a checkbox input element wrapped in a label element
        /// </summary>
        public static MvcHtmlString BsCheckBoxFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression)
        {
            return BsCheckBoxFor(helper, expression, (object)null);
        }

        /// <summary>
        /// Returns a checkbox input element wrapped in a label element
        /// </summary>
        public static MvcHtmlString BsCheckBoxFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, object htmlAttributes)
        {
            return BsCheckBoxFor(helper, expression, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Returns a checkbox input element wrapped in a label element
        /// </summary>
        public static MvcHtmlString BsCheckBoxFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var fieldName = ExpressionHelper.GetExpressionText(expression);
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? fieldName.Split('.').Last();

            var labelTag = new TagBuilder("label");
            var labelHtml = new StringBuilder(labelTag.ToString(TagRenderMode.StartTag));
            labelHtml.Append(helper.CheckBoxFor(expression, htmlAttributes));
            labelHtml.AppendLine(labelText);
            labelHtml.AppendLine(labelTag.ToString(TagRenderMode.EndTag));

            return MvcHtmlString.Create(labelHtml.ToString());
        }
        #endregion

        #region RadioButton
        public static MvcHtmlString BsRadioButton(this HtmlHelper htmlHelper, string name)
        {
            return BsRadioButton(htmlHelper, name, htmlAttributes: (object)null);
        }

        public static MvcHtmlString BsRadioButton(this HtmlHelper htmlHelper, string name, bool isChecked)
        {
            return BsRadioButton(htmlHelper, name, isChecked, htmlAttributes: (object)null);
        }

        public static MvcHtmlString BsRadioButton(this HtmlHelper htmlHelper, string name, bool isChecked, object htmlAttributes)
        {
            return BsRadioButton(htmlHelper, name, isChecked, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString BsRadioButton(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return BsRadioButton(htmlHelper, name, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString BsRadioButton(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
        {
            return BsRadioButton(htmlHelper, name: name, isChecked: false, htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString BsRadioButton(this HtmlHelper htmlHelper, string name, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromStringExpression(name, htmlHelper.ViewData);
            var fieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? fieldName.Split('.').Last();

            var labelTag = new TagBuilder("label");
            var labelHtml = new StringBuilder(labelTag.ToString(TagRenderMode.StartTag));
            labelHtml.Append(htmlHelper.RadioButton(name, isChecked, htmlAttributes));
            labelHtml.AppendLine(labelText);
            labelHtml.AppendLine(labelTag.ToString(TagRenderMode.EndTag));

            return MvcHtmlString.Create(labelHtml.ToString());
        }

        /// <summary>
        /// Returns a RadioButton element wrapped in a label element
        /// </summary>
        public static MvcHtmlString BsRadioButtonFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var fieldName = ExpressionHelper.GetExpressionText(expression);
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? fieldName.Split('.').Last();

            var labelTag = new TagBuilder("label");
            var labelHtml = new StringBuilder(labelTag.ToString(TagRenderMode.StartTag));
            labelHtml.Append(helper.RadioButtonFor(expression, htmlAttributes));
            labelHtml.AppendLine(labelText);
            labelHtml.AppendLine(labelTag.ToString(TagRenderMode.EndTag));

            return MvcHtmlString.Create(labelHtml.ToString());
        }
        public static MvcHtmlString BsRadioButtonFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression)
        {
            return BsRadioButtonFor(helper, expression, (object)null);
        }
        public static MvcHtmlString BsRadioButtonFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, object htmlAttributes)
        {
            return BsRadioButtonFor(helper, expression, new RouteValueDictionary(htmlAttributes));
        }
        #endregion
    }
}