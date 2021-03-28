using ITSearch.Models.IFixit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.ViewModels
{
    public class GuideViewModel
    {
        public IFixitGuide Guide { get; set; }
        public JsonImage GuideImage { get; set; }
        public Prerequisite GuidePrerequisite { get; set; }
        public Step GuideStep { get; set; }
        public Tool GuideTool { get; set; }
        public Author GuideAuthor { get; set; }
        public Comment GuideComment { get; set; }
        public Datum GuideDatum { get; set; }
        public Line GuideLine { get; set; }
    }
}
