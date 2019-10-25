using DevAssessment.Models;
using System.Collections.Generic;

namespace DevAssessment.Services
{
    public interface IMenuService
    {
        IEnumerable<Item> Items { get; }

        void LoadMenuItems();
        void ClearMenuItems();
    }
}
