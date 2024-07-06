namespace InterviewTestQA
{
    using InterviewTestQA.InterviewTestAutomation;
    using Newtonsoft.Json;
    using Xunit;
    using Xunit.Abstractions;
    public class JSONTest
    {
        private readonly ITestOutputHelper output;
        private static readonly string PathToAppSettings = Path.Combine(Environment.CurrentDirectory, "InterviewTestAutomation\\Data\\Cost Analysis.json");
        //private static string sFile = Path.Combine(PathToAppSettings, @"\InterviewTestAutomation\InterviewTestAutomation\Data\Cost Analysis.json");

        public JSONTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CheckjsonFilesize()
        {

            var obj = ReadJson(PathToAppSettings);

            Assert.Equal(53, obj.Count);



        }

        [Fact]
        public void LinqOrdering()
        {
            var obj = ReadJson(PathToAppSettings);
            var dummy = (from num in obj orderby num.YearId descending select num).Take(1);
            var result = dummy.ToList();
            Assert.Equal(124, result[0].CountryId);


        }

        [Fact]
        public void LinqSum()
        {
            var obj = ReadJson(PathToAppSettings);
            var totalcost = (from total in obj where total.YearId.Equals("2016") select total).Sum(e => e.Cost);
            Assert.Equal(77911.3744561, totalcost);
        }

        public List<CostData>? ReadJson(string path)
        {

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("No 'specflow.json' file found! Please make sure the file exists!");
            }
            else
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<CostData>>(json);
                }
            }
        }
    }
}