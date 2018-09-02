using AutoMapper;
using System;

namespace ExMan.Shared.Core.AutoMapper
{
    public sealed class AutoMapperConfiguration
    {

        /// <summary>
        /// http://geekswithblogs.net/BlackRabbitCoder/archive/2010/05/19/c-system.lazylttgt-and-the-singleton-design-pattern.aspx
        /// The .net provided lazy initialization and singleton design pattern usage
        /// </summary>
        private static readonly Lazy<AutoMapperConfiguration> autoMapperConfigurationInstance
            = new Lazy<AutoMapperConfiguration>(() => new AutoMapperConfiguration());

        public static AutoMapperConfiguration Instance
        {
            get
            {
                return autoMapperConfigurationInstance.Value;
            }
        }

        public void InitializeAutoMapper()
        {
            Mapper.Initialize(
                config =>
                {
                    config.AddProfile<DTOToEntityMapper>();
                });
        }

    }
}
