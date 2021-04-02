using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace SistemaVotacao.DataAccess
{
    public class BaseDataAccess
    {
        protected readonly DynamoDBContext _context;

        public BaseDataAccess()
        {
            _context = new DynamoDBContext(new AmazonDynamoDBClient());
        }
    }
}
