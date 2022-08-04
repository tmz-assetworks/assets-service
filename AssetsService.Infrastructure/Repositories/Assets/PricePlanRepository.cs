using AssetsService.Core.Entities;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class PricePlanRepository : Repository<AssetsService.Core.Entities.PricePlan>, IPricePlanRepository
    {
        public PricePlanRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<AssetsService.Core.Entities.PricePlan>> GetPricePlanById(long pricePlanId)
        {
            return await _dbContext.PricePlan
                .Where(abc => abc.Id == pricePlanId)
                .ToListAsync();
        }
         public async Task<List<PricePlan>> GetAllPricePlan()
        {
            return await _dbContext.PricePlan
                 .Select(abc => new PricePlan
                 {
                     Id = abc.Id,
                     CustomerName = abc.CustomerName,
                     CreatedBy = abc.CreatedBy,
                     CreatedOn = abc.CreatedOn,
                     PricingPlanName = abc.PricingPlanName,
                     Description = abc.Description,
                     ModifiedBy = abc.ModifiedBy,
                     ModifiedOn = abc.ModifiedOn,
                     CurrencyId = abc.CurrencyId,
                     ValidFrom = abc.ValidFrom,
                     ValidTo = abc.ValidTo,
                     LevelId = abc.LevelId,
                     PriceTypeId = abc.PriceTypeId,
                     UnitId = abc.UnitId,
                     Price = abc.Price,
                     ParkingFee = abc.ParkingFee,
                     GracePeriod = abc.GracePeriod,
                     TransactionFees = abc.TransactionFees,
                     SalaryTax = abc.SalaryTax,
                     SalesTax = abc.SalesTax,
                     PriceTypeName = abc.PriceTypeName,
                     IsActive = abc.IsActive,
                     Currency = (from obls in _dbContext.Currency.Where(x => x.CurrencyId == abc.CurrencyId)
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
                              Level = (from obls in _dbContext.Level.Where(x => x.Id == abc.LevelId)
                              select new Level
                              {
                                  Id = obls.Id,
                                  LevelRank = obls.LevelRank,
                                  IsActive = obls.IsActive,
                                  CreatedBy = obls.CreatedBy,
                                  CreatedOn = obls.CreatedOn,
                                  ModifiedBy = obls.ModifiedBy,
                                  ModifiedOn = obls.ModifiedOn,

                              }).FirstOrDefault(),
                               Unit = (from obls in _dbContext.Unit.Where(x => x.Id == abc.UnitId)
                              select new Unit
                              {
                                  Id = obls.Id,
                                  UnitName = obls.UnitName,
                                  IsActive = obls.IsActive,
                                  CreatedBy = obls.CreatedBy,
                                  CreatedOn = obls.CreatedOn,
                                  ModifiedBy = obls.ModifiedBy,
                                  ModifiedOn = obls.ModifiedOn,

                              }).FirstOrDefault(),
                              PriceType = (from obls in _dbContext.PriceType.Where(x => x.Id == abc.PriceTypeId)
                              select new PriceType
                              {
                                  Id = obls.Id,
                                  PriceTypeName = obls.PriceTypeName,
                                  IsActive = obls.IsActive,
                                  CreatedBy = obls.CreatedBy,
                                  CreatedOn = obls.CreatedOn,
                                  ModifiedBy = obls.ModifiedBy,
                                  ModifiedOn = obls.ModifiedOn,

                              }).FirstOrDefault(),
                               })
                 .ToListAsync();
                 }
                  public async Task<PricePlan> GetByIdPricePlan(long PricePlanId)
        {
               return  _dbContext.PricePlan
                 .Select(abc => new PricePlan
                 {
                     Id = abc.Id,
                     CustomerName = abc.CustomerName,
                     CreatedBy = abc.CreatedBy,
                     CreatedOn = abc.CreatedOn,
                     PricingPlanName = abc.PricingPlanName,
                     Description = abc.Description,
                     ModifiedBy = abc.ModifiedBy,
                     ModifiedOn = abc.ModifiedOn,
                     CurrencyId = abc.CurrencyId,
                     ValidFrom = abc.ValidFrom,
                     ValidTo = abc.ValidTo,
                     LevelId = abc.LevelId,
                     PriceTypeId = abc.PriceTypeId,
                     UnitId = abc.UnitId,
                     Price = abc.Price,
                     ParkingFee = abc.ParkingFee,
                     GracePeriod = abc.GracePeriod,
                     TransactionFees = abc.TransactionFees,
                     SalaryTax = abc.SalaryTax,
                     SalesTax = abc.SalesTax,
                     PriceTypeName = abc.PriceTypeName,
                     IsActive = abc.IsActive,
                     Currency = (from obls in _dbContext.Currency.Where(x => x.CurrencyId == abc.CurrencyId)
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
                              Level = (from obls in _dbContext.Level.Where(x => x.Id == abc.LevelId)
                              select new Level
                              {
                                  Id = obls.Id,
                                  LevelRank = obls.LevelRank,
                                  IsActive = obls.IsActive,
                                  CreatedBy = obls.CreatedBy,
                                  CreatedOn = obls.CreatedOn,
                                  ModifiedBy = obls.ModifiedBy,
                                  ModifiedOn = obls.ModifiedOn,

                              }).FirstOrDefault(),
                               Unit = (from obls in _dbContext.Unit.Where(x => x.Id == abc.UnitId)
                              select new Unit
                              {
                                  Id = obls.Id,
                                  UnitName = obls.UnitName,
                                  IsActive = obls.IsActive,
                                  CreatedBy = obls.CreatedBy,
                                  CreatedOn = obls.CreatedOn,
                                  ModifiedBy = obls.ModifiedBy,
                                  ModifiedOn = obls.ModifiedOn,

                              }).FirstOrDefault(),
                              PriceType = (from obls in _dbContext.PriceType.Where(x => x.Id == abc.PriceTypeId)
                              select new PriceType
                              {
                                  Id = obls.Id,
                                  PriceTypeName = obls.PriceTypeName,
                                  IsActive = obls.IsActive,
                                  CreatedBy = obls.CreatedBy,
                                  CreatedOn = obls.CreatedOn,
                                  ModifiedBy = obls.ModifiedBy,
                                  ModifiedOn = obls.ModifiedOn,

                              }).FirstOrDefault()
                                }).Where(x => x.Id == PricePlanId).FirstOrDefault();
        }

    }
}