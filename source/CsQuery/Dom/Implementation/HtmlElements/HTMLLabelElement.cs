﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsQuery.HtmlParser;

namespace CsQuery.Implementation
{   
    /// <summary>
    /// A LABEL element.
    /// </summary>
    ///
    /// <url>
    /// http://dev.w3.org/html5/spec/single-page.html#the-label-element
    /// </url>

    public class HTMLLabelElement : DomElement, IHTMLLabelElement
    {
        public HTMLLabelElement()
            : base(HtmlData.tagLABEL)
        {
        }

        /// <summary>
        /// The form to which the label belongs
        /// </summary>

        public IHTMLFormElement Form
        {
            get
            {
                return (IHTMLFormElement)Closest(HtmlData.tagFORM);
            }
        }

        /// <summary>
        /// Gets or sets the for attribute
        /// </summary>

        public string HtmlFor 
        {
            get
            {
                return GetAttribute("for");   
            }
            set{
                SetAttribute("for",value);
            }
        }

        /// <summary>
        /// The control bound to this label. If the "for" attribute is set, this is the control with that
        /// ID. If not, the first input control that is a child of the label will be returned.
        /// </summary>

        public IDomElement Control {
            get
            {
                var id = HtmlFor;
                if (!String.IsNullOrEmpty(id))
                {
                    return Document.GetElementById(id);
                }
                else
                {
                    foreach (var el in DescendantElements())
                    {
                        if (HtmlData.IsFormInputControl(el.NodeNameID))
                        {
                            return el;
                        }
                    }
                    return null;
                }
            }
        }
    }
}
