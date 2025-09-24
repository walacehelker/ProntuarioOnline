using Microsoft.AspNetCore.Identity;

namespace Implementations.Identity;
public class PortugueseIdentityErrorDescriber : IdentityErrorDescriber
{
  public override IdentityError PasswordRequiresUpper()
  {
    return new IdentityError
    {
      Code = nameof(PasswordRequiresUpper),
      Description = "A senha deve conter pelo menos uma letra maiúscula (A-Z)."
    };
  }

  public override IdentityError PasswordRequiresNonAlphanumeric()
  {
    return new IdentityError
    {
      Code = nameof(PasswordRequiresNonAlphanumeric),
      Description = "A senha deve conter pelo menos um caractere especial (ex.: @, #, !, $)."
    };
  }

  public override IdentityError PasswordTooShort(int length)
  {
    return new IdentityError
    {
      Code = nameof(PasswordTooShort),
      Description = $"A senha deve ter pelo menos {length} caracteres."
    };
  }

  public override IdentityError PasswordRequiresDigit()
  {
    return new IdentityError
    {
      Code = nameof(PasswordRequiresDigit),
      Description = "A senha deve conter pelo menos um número (0-9)."
    };
  }

  public override IdentityError PasswordRequiresLower()
  {
    return new IdentityError
    {
      Code = nameof(PasswordRequiresLower),
      Description = "A senha deve conter pelo menos uma letra minúscula (a-z)."
    };
  }
}