using FluentValidation;
using TweetBook.Contracts.V1.Requests;

namespace TweetBook.Validator
{
    public class CreateTagRequestValidator : AbstractValidator<CreateTagRequest>
    {
        public CreateTagRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Matches("^[A-Za-z0-9 ]*$");

            /*
            RuleFor(x => x.Name)
                .Must(s => s.Contains("Special"));
            */
        }
    }
}