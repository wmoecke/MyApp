using MyApp.Domain;
using Newtonsoft.Json.Linq;

namespace MyApp.Application 
{ 
    public class DataUpsertJob 
    { 
        private readonly IRepository<DataEntity> _repository; 
        private readonly HttpClient _httpClient = new(); 
        public DataUpsertJob(IRepository<DataEntity> repository) { _repository = repository; } 
        public async Task Execute() 
        { 
            var response = await _httpClient.GetStringAsync("https://collectionapi.metmuseum.org/public/collection/v1/departments"); 
            var json = JObject.Parse(response); 
            
            foreach (var entry in json["departments"]) 
            { 
                var dataEntity = new DataEntity { Value = entry["displayName"].ToString() }; 
                await _repository.AddAsync(dataEntity); 
            } 
        } 
    } 
}