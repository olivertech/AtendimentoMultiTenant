﻿namespace AtendimentoMultiTenant.Core.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Propriedade que irá definir o isolamento a nível de row nas tabelas dos sistemas
        /// </summary>
        public string? TenantId { get; set; } = null;
    }
}
