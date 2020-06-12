using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purposes.Models;

namespace Purposes.ViewModels
{
    public class SortViewModel
    {
        public SortState CreationSort { get; private set; }
        public SortState NameSort { get; private set; }
        public SortState DateSort { get; private set; }
        public SortState CompletedSort { get; private set; }
        public SortState ImportanceSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            CreationSort = sortOrder == SortState.CreationAsc ? SortState.CreationDesc : SortState.CreationAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            DateSort = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            CompletedSort = sortOrder == SortState.CompletedAsc ? SortState.CompletedDesc : SortState.CompletedAsc;
            ImportanceSort = sortOrder == SortState.ImportanceAsc ? SortState.ImportanceDesc : SortState.ImportanceAsc;
            Current = sortOrder;
        }
    }
}
