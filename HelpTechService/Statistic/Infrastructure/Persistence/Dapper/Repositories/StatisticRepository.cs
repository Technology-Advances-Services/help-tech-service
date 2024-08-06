using Dapper;
using System.Data;
using HelpTechService.Statistic.Domain.Model.ValueObjects;
using HelpTechService.Statistic.Domain.Repositories;

namespace HelpTechService.Statistic.Infrastructure.Persistence.Dapper.Repositories
{
    internal class StatisticRepository
        (IDbConnection dbConnection) :
        IStatisticRepository
    {
        public async Task<dynamic?> GeneralTechnicalStatisticAsync
            (int technicalId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@technical_id", technicalId);

            var result = await dbConnection.QueryAsync<dynamic>
                ("sp_general_technical_statistic", parameters,
                commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<dynamic?> DetailedTechnicalStatisticAsync
            (int technicalId, ETypeStatistic typeStatistic)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@technical_id", technicalId);
            parameters.Add("@type_statistic", typeStatistic.ToString());

            var result = await dbConnection.QueryAsync<dynamic>
                ("sp_detailed_technical_statistic", parameters,
                commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<dynamic?> ReviewStatisticAsync
            (int technicalId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@technical_id", technicalId);

            var result = await dbConnection.QueryAsync<dynamic>
                ("sp_review_statistic", parameters,
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}