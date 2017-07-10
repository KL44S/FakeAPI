using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.SqlServerDao.EntityModel;
using DataAccess.SqlServerDao.Mapping;
using Exceptions;

namespace DataAccess.SqlServerDao
{
    public class RequirementSqlServerDao : RequirementDao
    {
        private RequirementMapping _requirementMapping;

        public RequirementSqlServerDao()
        {
            this._requirementMapping = new RequirementMapping();
        }

        public override void Create(Model.Requirement Requirement)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Requirement EntityRequirement = this._requirementMapping.MapModel(Requirement);

                ObrasEntities.Requirement.Add(EntityRequirement);
                ObrasEntities.SaveChanges();
            }
        }

        public override void Delete(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Requirement EntityRequirement = ObrasEntities.Requirement.FirstOrDefault(Requirement => 
                                                                                    Requirement.requirementNumber.Equals(RequirementNumber));

                if (EntityRequirement == null)
                    throw new EntityNotFoundException();

                ObrasEntities.Requirement.Remove(EntityRequirement);
                ObrasEntities.SaveChanges();
            }
        }

        public override IEnumerable<Model.Requirement> GetAll()
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                IEnumerable<Model.Requirement> Requirements = this._requirementMapping.UnMapEntities(ObrasEntities.Requirement.ToList());

                return Requirements;
            }
        }

        public override Model.Requirement GetRequirementByRequirementNumber(int RequirementNumber)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Requirement FoundRequirement = ObrasEntities.Requirement.FirstOrDefault(Requirement => 
                                                                            Requirement.requirementNumber.Equals(RequirementNumber));

                if (FoundRequirement == null)
                    throw new EntityNotFoundException();

                return this._requirementMapping.UnMapEntity(FoundRequirement);
            }
        }

        public override void Update(Model.Requirement Requirement)
        {
            using (ObrasEntities ObrasEntities = new ObrasEntities())
            {
                EntityModel.Requirement FoundRequirement = ObrasEntities.Requirement.FirstOrDefault(EntityRequirement =>
                                                                            EntityRequirement.requirementNumber.Equals(Requirement.RequirementNumber));

                if (FoundRequirement == null)
                    throw new EntityNotFoundException();

                this._requirementMapping.MapModel(Requirement, FoundRequirement);
                ObrasEntities.SaveChanges();
            }
        }
    }
}
