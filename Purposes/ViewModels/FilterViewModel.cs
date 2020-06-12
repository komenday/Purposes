using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Purposes.Models;

namespace Purposes.ViewModels
{
    public class FilterViewModel
    {
        public string SelectedName { get; private set; }

        public FilterViewModel(string name)
        {
            SelectedName = name;
        }
    }
}
