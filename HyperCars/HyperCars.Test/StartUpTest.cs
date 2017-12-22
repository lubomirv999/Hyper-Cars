namespace HyperCars.Test
{
    using AutoMapper;
    using HyperCars.Web.Infrastructure.Mapping;

    public class StartUpTest
    {
        private static bool TestInitialized = false;

        public static void Initialize()
        {
            if (!TestInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

                TestInitialized = true;
            }
        }
    }
}