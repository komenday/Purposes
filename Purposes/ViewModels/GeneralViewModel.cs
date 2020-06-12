using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purposes.Models;

namespace Purposes.ViewModels
{
    public class GeneralViewModel
    {
        public IEnumerable<Purpose> Purposes { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
