﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Model;

namespace Mobile.ViewModel.Helpers
{
    public interface ILineProvider
    {
        Task<ObservableCollection<Line>> GetAllAsync();
    }
}