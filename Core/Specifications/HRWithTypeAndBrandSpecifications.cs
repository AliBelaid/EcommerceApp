using Core.Entities;
using Core.Entities.hr;

namespace Core.Specifications {
    public class HRWithTypeAndBrandSpecifications : BaseSpecifications<Employees> {
        public HRWithTypeAndBrandSpecifications()    {
            AddInclude(x => x.Departments);
            AddInclude(x => x.Designation);
          

        }

        public HRWithTypeAndBrandSpecifications (int id) : base (x => x.Id == id) {
           AddInclude(x => x.Departments);
            AddInclude(x => x.Designation);
        }
    }
}