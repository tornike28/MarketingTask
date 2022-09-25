using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.DistributorAggregate
{
    public class Recomendation
    {
        public Recomendation(string distributorSecondaryId, int hierarchyLevel)
        {
            DistributorSecondaryId = distributorSecondaryId;
            HierarchyLevel = hierarchyLevel;
        }
        public string DistributorSecondaryId { get; private set; }
        public int HierarchyLevel { get; private set; }

        public void IncreaseLevel()
        {
            HierarchyLevel++;
        }
    }
}
