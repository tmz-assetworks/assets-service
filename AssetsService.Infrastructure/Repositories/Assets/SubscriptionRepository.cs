using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Core.Entities;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class SubscriptionRepository : Repository<AssetsService.Core.Entities.SubscriptionPlan>, ISubscriptionPlanRepository
    {
        public SubscriptionRepository(AssetsService.Infrastructure.DBContext.DBContextCore _dbContext) : base(_dbContext)
        {

        }
        public async Task<List<SubscriptionPlan>> GetAllSubscriptionPlan()
        {
            return await _dbContext.SubscriptionPlan
                 .Select(m => new SubscriptionPlan
                 {
                     CustomerId = m.CustomerId,
                     CustomerName = m.CustomerName,
                     SubscriptionPlanName = m.SubscriptionPlanName,
                     Description = m.Description,
                     CurrencyId = m.CurrencyId,
                     ValidFrom = m.ValidFrom,
                     ValidTo = m.ValidTo,
                     StatusId = m.StatusId,
                     SubscriptionsGroupId = m.SubscriptionsGroupId,
                     SubscriptionsDetails = m.SubscriptionsDetails,
                     SubscriptionsValue = m.SubscriptionsValue,
                     SubscriptionsGroup = (from obls in _dbContext.SubscriptionsGroup.Where(x => x.Id == m.SubscriptionsGroupId)
                                   select new SubscriptionsGroup
                                   {
                                       Id = obls.Id,
                                       SubscriptionName = obls.SubscriptionName,
                                       IsActive = obls.IsActive,
                                       CreatedBy = obls.CreatedBy,
                                       ModifiedBy = obls.ModifiedBy,
                                       ModifiedOn = obls.ModifiedOn,
                                       CreatedOn = (obls.CreatedOn == DateTime.MinValue ? DateTime.MinValue : obls.CreatedOn),

                                   }).FirstOrDefault(),
                     Status = (from obls in _dbContext.Status.Where(x => x.Id == m.StatusId)
                               select new Status
                               {
                                   Id = obls.Id,
                                   StatusName = obls.StatusName,
                                   IsActive = obls.IsActive,
                                   CreatedBy = obls.CreatedBy,
                                   CreatedOn = obls.CreatedOn,
                                   ModifiedBy = obls.ModifiedBy,
                                   ModifiedOn = obls.ModifiedOn,

                               }).FirstOrDefault(),
                     currency = (from obls in _dbContext.Currency.Where(x => x.CurrencyId == m.CurrencyId)
                                 select new Currency
                                 {
                                     CurrencyId = obls.CurrencyId,
                                     CurrencyName = obls.CurrencyName,
                                     IsActive = obls.IsActive,
                                     CreatedBy = obls.CreatedBy,
                                     CreatedOn = obls.CreatedOn,
                                     ModifiedBy = obls.ModifiedBy,
                                     ModifiedOn = obls.ModifiedOn,
                                 }).FirstOrDefault(),
                 })
                 .ToListAsync();
        }
        public async Task<SubscriptionPlan> GetSubscriptionPlanById(long customerId)
        {
            return _dbContext.SubscriptionPlan
                 .Select(m => new SubscriptionPlan
                 {
                     CustomerId = m.CustomerId,
                     CustomerName = m.CustomerName,
                     SubscriptionPlanName = m.SubscriptionPlanName,
                     Description = m.Description,
                     CurrencyId = m.CurrencyId,
                     ValidFrom = m.ValidFrom,
                     ValidTo = m.ValidTo,
                     StatusId = m.StatusId,
                     SubscriptionsGroupId = m.SubscriptionsGroupId,
                     SubscriptionsDetails = m.SubscriptionsDetails,
                     SubscriptionsValue = m.SubscriptionsValue,

                     SubscriptionsGroup = (from obls in _dbContext.SubscriptionsGroup.Where(x => x.Id == m.SubscriptionsGroupId)
                                           select new SubscriptionsGroup
                                           {
                                               Id = obls.Id,
                                               SubscriptionName = obls.SubscriptionName,
                                               IsActive = obls.IsActive,
                                               CreatedBy = obls.CreatedBy,
                                               ModifiedBy = obls.ModifiedBy,
                                               ModifiedOn = obls.ModifiedOn,
                                               CreatedOn = (obls.CreatedOn == DateTime.MinValue ? DateTime.MinValue : obls.CreatedOn),

                                           }).FirstOrDefault(),
                     Status = (from obls in _dbContext.Status.Where(x => x.Id == m.StatusId)
                               select new Status
                               {
                                   Id = obls.Id,
                                   StatusName = obls.StatusName,
                                   IsActive = obls.IsActive,
                                   CreatedBy = obls.CreatedBy,
                                   CreatedOn = obls.CreatedOn,
                                   ModifiedBy = obls.ModifiedBy,
                                   ModifiedOn = obls.ModifiedOn,

                               }).FirstOrDefault(),
                     currency = (from obls in _dbContext.Currency.Where(x => x.CurrencyId == m.CurrencyId)
                                 select new Currency
                                 {
                                     CurrencyId = obls.CurrencyId,
                                     CurrencyName = obls.CurrencyName,
                                     IsActive=obls.IsActive,
                                     CreatedBy=obls.CreatedBy,
                                     CreatedOn=obls.CreatedOn,
                                     ModifiedBy=obls.ModifiedBy,
                                     ModifiedOn=obls.ModifiedOn,
                                 }).FirstOrDefault(),

                 }).Where(x => x.CustomerId == customerId).FirstOrDefault();

        }
    }
}
