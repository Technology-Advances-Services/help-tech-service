using HelpTechService.Attention.Application.Internal.OutboundServices.ACL;
using HelpTechService.Attention.Domain.Model.Commands.Review;
using HelpTechService.Attention.Domain.Repositories;
using HelpTechService.Attention.Domain.Services.Review;
using HelpTechService.Shared.Domain.Repositories;

namespace HelpTechService.Attention.Application.Internal.CommandServices
{
    internal class ReviewCommandService
        (IReviewRepository reviewRepository,
        IUnitOfWork unitOfWork,
        ExternalIamService externalIamService) :
        IReviewCommandService
    {
        public async Task<bool> Handle
            (AddReviewToJobCommand command)
        {
            try
            {
                if (await externalIamService
                    .ExistsTechnicalById
                    (command.TechnicalId)
                    is false ||
                    await externalIamService
                    .ExistsConsumerById
                    (command.ConsumerId)
                    is false) return false;

                await reviewRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}