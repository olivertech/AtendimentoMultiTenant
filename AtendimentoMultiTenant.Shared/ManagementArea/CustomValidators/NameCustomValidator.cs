﻿#pragma warning disable CS8604 // Possible null reference argument.
namespace AtendimentoMultiTenant.Shared.ManagementArea.CustomValidators
{
    /// <summary>
    /// Valida os nomes de clientes. Só aceita letras, números e "_" na formação do nome
    /// </summary>
    public class NameCustomValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var regex = new Regex(@"^[a-zA-Z0-9_]+$");

            if (value is not null)
            {
                if (!Regex.IsMatch(value!.ToString(), regex.ToString()))
                    return false;
                else
                    return true;
            }
            else
            {
                return false;
            }
        }
    }
}
#pragma warning restore CS8604 // Possible null reference argument.
