﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digirati.IIIF3.Model.JSONLD;

namespace Digirati.IIIF3.Model.Types
{
    public class AnnotationPage : JSONLDBase
    {
        public List<Annotation> Items { get; set; }
        public List<JSONLDString> Label { get; set; }
    }
}
