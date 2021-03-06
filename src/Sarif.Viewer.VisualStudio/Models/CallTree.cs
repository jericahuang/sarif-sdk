﻿// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Sarif.Viewer.Models
{
    public class CallTree : NotifyPropertyChangedObject
    {
        private CodeLocationObject _selectedItem;
        private ObservableCollection<CallTreeNode> _topLevelNodes;

        public CallTree(IList<CallTreeNode> topLevelNodes)
        {
            TopLevelNodes = new ObservableCollection<CallTreeNode>(topLevelNodes);
        }

        public ObservableCollection<CallTreeNode> TopLevelNodes
        {
            get
            {
                return _topLevelNodes;
            }
            set
            {
                _topLevelNodes = value;

                // Set this object as the CallTree for the child nodes.
                if (_topLevelNodes != null)
                {
                    for (int i = 0; i < _topLevelNodes.Count; i++)
                    {
                        _topLevelNodes[i].CallTree = this;
                    }
                }
            }
        }

        public CodeLocationObject SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                // Remove the existing highlighting.
                if (_selectedItem != null)
                {
                    _selectedItem.ApplyDefaultSourceFileHighlighting();
                }

                _selectedItem = value;
                this.NotifyPropertyChanged(nameof(SelectedItem));

                // Navigate to the source of the selected node and highlight the region.
                if (_selectedItem != null)
                {
                    // Update the VS Properties window with the properties of the selected CallTreeNode.
                    SarifViewerPackage.SarifToolWindow.UpdateSelectionList(_selectedItem.TypeDescriptor);

                    // Navigate to the source file of the selected CallTreeNode.
                    _selectedItem.NavigateTo();
                    _selectedItem.ApplySelectionSourceFileHighlighting();
                }
            }
        }
    }
}
