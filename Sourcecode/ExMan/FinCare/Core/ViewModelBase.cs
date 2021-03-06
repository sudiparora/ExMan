﻿using Microsoft.Practices.ServiceLocation;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCare.Core
{
    public class ViewModelBase : BindableBase, INavigationAware
    {

        #region Fields & Properties

        public ICache Cache
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ICache>();
            }
        }

        public IRegionManager RegionManager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRegionManager>();
            }
        }

        #endregion

        #region NavigationAware Methods

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        { }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        { }

        public virtual void NavigationCompleted(NavigationResult obj)
        { }

        #endregion
    }
}
