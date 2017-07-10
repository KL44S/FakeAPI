using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SqlServerDao.EntityModel;
using Model;

namespace DataAccess.SqlServerDao.Mapping
{
    internal class RequirementMapping : Mapping<Model.Requirement, EntityModel.Requirement>
    {
        protected override EntityModel.Requirement CreateEntity()
        {
            return new EntityModel.Requirement();
        }

        protected override Model.Requirement CreateModel()
        {
            return new Model.Requirement();
        }

        internal override void MapModel(Model.Requirement RequirementModel, EntityModel.Requirement RequirementEntity)
        {
            RequirementEntity.certificationDays = RequirementModel.CertificationDays;
            RequirementEntity.provider = RequirementModel.Provider;
            RequirementEntity.purchaseOrderExcercise = RequirementModel.PurchaseOrderExcercise;
            RequirementEntity.purchaseOrderNumber = RequirementModel.PurchaseOrder;
            RequirementEntity.requirementNumber = RequirementModel.RequirementNumber;
        }

        internal override void UnMapEntity(EntityModel.Requirement RequirementEntity, Model.Requirement RequirementModel)
        {
            RequirementModel.CertificationDays = RequirementEntity.certificationDays;
            RequirementModel.Provider = RequirementEntity.provider;
            RequirementModel.PurchaseOrderExcercise = RequirementEntity.purchaseOrderExcercise;
            RequirementModel.PurchaseOrder = RequirementEntity.purchaseOrderNumber;
            RequirementModel.RequirementNumber = RequirementEntity.requirementNumber;
        }
    }
}
