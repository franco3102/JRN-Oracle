using JRN_Oracle.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JRN_Oracle
{
    public class APIHandler
    {
        //private readonly string connString = "Server=PS-SVR;Database=ProSnap;User ID=sa;Password=sa_P@ssw0rd3L!5!!!;Encrypt=False";
        private readonly string connString = "Server=PS-SVR;Database=IDP_JResources;User ID=sa;Password=sa_P@ssw0rd3L!5!!!;Encrypt=False";
        DataTable dt = new DataTable();

        //public void GetSinglePayloadCreateInvoice()
        //{
        //    using(SqlConnection conn = new SqlConnection(connString))
        //    {
        //        conn.Open();
        //        string query = "SELECT TOP 1 * FROM JRNDummy_CreateInvoicePayload";
        //        using(SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            using(SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                dt.Load(reader);
        //            }
        //        }
        //    }

        //    PayloadModel payload = Utility.ConvertDataTableToList<PayloadModel>(dt)[0];
        //    AttachmentModel attachment = new AttachmentModel
        //    {
        //        Type = "File",
        //        FileName = "REST Invoice related attachment.txt",
        //        Title = "REST Invoice related attachment",
        //        Description = "REST Invoice related attachment",
        //        Category = "From Supplier",
        //        FileUrl = "/content/conn/ContentRepository/uuid/dDocID%3a407437?XFND_SCHEME_ID=1&XFND_CERT_FP=01A8AFB3277D68B1E0D8CFC44C59578044ADBAE0&XFND_RANDOM=2869500116500884411&XFND_EXPIRES=1536137883284&XFND_SIGNATURE=j1ybpNkr471dYeRg85cBp-j~nC38M-jZhC048FSZs13sKO5O9uEmyObHD1nwCO6vg2BB5msYya2tBqfYiZBE380SWm4xLWF6XEgl23nNnYpqfV~36JNI3b~gXHSP-7yrs5qB~MDT7rPRDi9eGUUByuXtkV1Qb~QZdnSxBYiTPl~5GKLPgRygYWjiq1VykWln0X52US98VW4G5aS6KVewwAPJsusw51c14Z1tkAkbX5No08eQgw2fCEft0syNgzSkWcu9r04681rv-JMZW8tv43waaI3ZDefbysjoo7vXWjYjcwKx~1p0~OMBfQc2Qp~Te1hvTgjoOy8EdMtnz1FmJA__&ld=407437&download"
        //    };
        //    payload.attachments = new List<AttachmentModel> 
        //    {
        //        new AttachmentModel
        //        {
        //            Type = "File-Test01",
        //            FileName = "REST Invoice related attachment-Test01.txt",
        //            Title = "REST Invoice related attachment-Test01",
        //            Description = "REST Invoice related attachment-Test01",
        //            Category = "From Supplier-Test01",
        //            FileUrl = "/content/conn/ContentRepository/uuid/dDocID%3a407437?XFND_SCHEME_ID=1&XFND_CERT_FP=01A8AFB3277D68B1E0D8CFC44C59578044ADBAE0&XFND_RANDOM=2869500116500884411&XFND_EXPIRES=1536137883284&XFND_SIGNATURE=j1ybpNkr471dYeRg85cBp-j~nC38M-jZhC048FSZs13sKO5O9uEmyObHD1nwCO6vg2BB5msYya2tBqfYiZBE380SWm4xLWF6XEgl23nNnYpqfV~36JNI3b~gXHSP-7yrs5qB~MDT7rPRDi9eGUUByuXtkV1Qb~QZdnSxBYiTPl~5GKLPgRygYWjiq1VykWln0X52US98VW4G5aS6KVewwAPJsusw51c14Z1tkAkbX5No08eQgw2fCEft0syNgzSkWcu9r04681rv-JMZW8tv43waaI3ZDefbysjoo7vXWjYjcwKx~1p0~OMBfQc2Qp~Te1hvTgjoOy8EdMtnz1FmJA__&ld=407437&download"
        //        },
        //        new AttachmentModel
        //        {
        //            Type = "File-Test02",
        //            FileName = "REST Invoice related attachment-Test02.txt",
        //            Title = "REST Invoice related attachment-Test02",
        //            Description = "REST Invoice related attachment-Test02",
        //            Category = "From Supplier-Test02",
        //            FileUrl = "/content/conn/ContentRepository/uuid/dDocID%3a407437?XFND_SCHEME_ID=1&XFND_CERT_FP=01A8AFB3277D68B1E0D8CFC44C59578044ADBAE0&XFND_RANDOM=2869500116500884411&XFND_EXPIRES=1536137883284&XFND_SIGNATURE=j1ybpNkr471dYeRg85cBp-j~nC38M-jZhC048FSZs13sKO5O9uEmyObHD1nwCO6vg2BB5msYya2tBqfYiZBE380SWm4xLWF6XEgl23nNnYpqfV~36JNI3b~gXHSP-7yrs5qB~MDT7rPRDi9eGUUByuXtkV1Qb~QZdnSxBYiTPl~5GKLPgRygYWjiq1VykWln0X52US98VW4G5aS6KVewwAPJsusw51c14Z1tkAkbX5No08eQgw2fCEft0syNgzSkWcu9r04681rv-JMZW8tv43waaI3ZDefbysjoo7vXWjYjcwKx~1p0~OMBfQc2Qp~Te1hvTgjoOy8EdMtnz1FmJA__&ld=407437&download"
        //        },
        //    };

        //    string PayloadAttachmentDisplay = $"[\n";
        //    int i = 0;
        //    foreach(var att in payload.attachments)
        //    {
        //        PayloadAttachmentDisplay += $"\t{{" +
        //            $"\n\t\t\"Type\": \"{att.Type}\"," +
        //            $"\n\t\t\"FileName\": \"{att.FileName}\"," +
        //            $"\n\t\t\"Title\": \"{att.Title}\"," +
        //            $"\n\t\t\"Description\": \"{att.Description}\"," +
        //            $"\n\t\t\"Category\": \"{att.Category}\"," +
        //            $"\n\t\t\"FileUrl\": \"{att.FileUrl}\"";
        //            //$"\n\t}}";

        //        if(i == payload.attachments.Count - 1)
        //        {
        //            PayloadAttachmentDisplay += $"\n\t}}";
        //        }
        //        else
        //        {
        //            PayloadAttachmentDisplay += $"\n\t}},\n";
        //        }
        //        i++;
        //    }
        //    PayloadAttachmentDisplay += $"\n]";

        //    string DisplayText = $"Payload Data" +
        //        $"\nInvoiceNumber: {payload.InvoiceNumber}," +
        //        $"\nInvoiceCurrency: {payload.InvoiceCurrency}," +
        //        $"\nInvoiceAmount: {payload.InvoiceAmount},    " +
        //        $"\nInvoiceDate: {payload.InvoiceDate}," +
        //        $"\nBusinessUnit: {payload.BusinessUnit},    " +
        //        $"\nSupplier: {payload.Supplier},    " +
        //        $"\nSupplierSite: {payload.SupplierSite},    " +
        //        $"\nRequester: {payload.Requester},    " +
        //        $"\nInvoiceGroup: {payload.InvoiceGroup},    " +
        //        $"\nDescription: {payload.Description}" +
        //        $"\nAttachments: \n{PayloadAttachmentDisplay}";

        //    Console.WriteLine(DisplayText);
        //}

        public InvoiceHeaderModel GetInvoiceHeader()
        {
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "usp_GetSingleTransactionInvoiceHeader";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@HeaderID", 10);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return Utility.ConvertDataTableToList<InvoiceHeaderModel>(dt)[0];
        }

        public async Task PostCreateInvoiceAsync()
        {
            InvoiceHeaderModel header = GetInvoiceHeader();
            //int? HeaderID = header.HeaderID;
            //header.HeaderID
            //header.Supplier = "MARMERO KARYA SEJAHTERA, PT";
            //header.SupplierSite = "BITUNG";
            //header.BusinessUnit = "JRBML BU";
            string url = "https://fa-exke-test-saasfaprod1.fa.ocs.oraclecloud.com/fscmRestApi/resources/11.13.18.05/invoices";
            string username = "elistec@jresources.com";
            string password = "Bky\\_J0x5A?9";
            using var client = new HttpClient();
            // Set up Basic Authentication
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            // Serialize payload to JSON
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            string jsonPayload = System.Text.Json.JsonSerializer.Serialize(header);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            Console.WriteLine("Payload is ready, begin to create the invoice");
            try
            {
                // Make the POST request
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Success! Response content:");
                    Console.WriteLine(responseContent);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error details:");
                    Console.WriteLine(errorContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task CreateInvoiceAsync()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT TOP 1 * FROM JRNDummy_CreateInvoicePayload";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            PayloadModel payload = Utility.ConvertDataTableToList<PayloadModel>(dt)[0];
            payload.Requester = null;
            payload.InvoiceNumber = payload.InvoiceNumber.Replace("Test01", "Test02");
            payload.attachments = new List<AttachmentModel>
            {
                new AttachmentModel
                {
                    Type = "File",
                    FileName = "REST Invoice related attachment-Test01.txt",
                    Title = "REST Invoice related attachment-Test01",
                    Description = "REST Invoice related attachment-Test01",
                    Category = "From Supplier",
                    FileUrl = "/content/conn/ContentRepository/uuid/dDocID%3a407437?XFND_SCHEME_ID=1&XFND_CERT_FP=01A8AFB3277D68B1E0D8CFC44C59578044ADBAE0&XFND_RANDOM=2869500116500884411&XFND_EXPIRES=1536137883284&XFND_SIGNATURE=j1ybpNkr471dYeRg85cBp-j~nC38M-jZhC048FSZs13sKO5O9uEmyObHD1nwCO6vg2BB5msYya2tBqfYiZBE380SWm4xLWF6XEgl23nNnYpqfV~36JNI3b~gXHSP-7yrs5qB~MDT7rPRDi9eGUUByuXtkV1Qb~QZdnSxBYiTPl~5GKLPgRygYWjiq1VykWln0X52US98VW4G5aS6KVewwAPJsusw51c14Z1tkAkbX5No08eQgw2fCEft0syNgzSkWcu9r04681rv-JMZW8tv43waaI3ZDefbysjoo7vXWjYjcwKx~1p0~OMBfQc2Qp~Te1hvTgjoOy8EdMtnz1FmJA__&ld=407437&download"
                },
                new AttachmentModel
                {
                    Type = "File",
                    FileName = "REST Invoice related attachment-Test02.txt",
                    Title = "REST Invoice related attachment-Test02",
                    Description = "REST Invoice related attachment-Test02",
                    Category = "From Supplier",
                    FileUrl = "/content/conn/ContentRepository/uuid/dDocID%3a407437?XFND_SCHEME_ID=1&XFND_CERT_FP=01A8AFB3277D68B1E0D8CFC44C59578044ADBAE0&XFND_RANDOM=2869500116500884411&XFND_EXPIRES=1536137883284&XFND_SIGNATURE=j1ybpNkr471dYeRg85cBp-j~nC38M-jZhC048FSZs13sKO5O9uEmyObHD1nwCO6vg2BB5msYya2tBqfYiZBE380SWm4xLWF6XEgl23nNnYpqfV~36JNI3b~gXHSP-7yrs5qB~MDT7rPRDi9eGUUByuXtkV1Qb~QZdnSxBYiTPl~5GKLPgRygYWjiq1VykWln0X52US98VW4G5aS6KVewwAPJsusw51c14Z1tkAkbX5No08eQgw2fCEft0syNgzSkWcu9r04681rv-JMZW8tv43waaI3ZDefbysjoo7vXWjYjcwKx~1p0~OMBfQc2Qp~Te1hvTgjoOy8EdMtnz1FmJA__&ld=407437&download"
                },
            };
            payload.invoiceDff = new List<InvoiceDffModel>();
            payload.invoiceInstallments = new List<InvoiceInstallmentModel>
            {
                new InvoiceInstallmentModel
                {
                    InstallmentNumber = 1,
                    DueDate = Convert.ToDateTime(payload.TermsDate).AddDays(1).ToString("yyyy-MM-dd"),
                    GrossAmount = 1100,
                },
                new InvoiceInstallmentModel
                {
                    InstallmentNumber = 2,
                    DueDate = Convert.ToDateTime(payload.TermsDate).AddDays(1).ToString("yyyy-MM-dd"),
                    GrossAmount = Convert.ToDecimal(1212.75),
                    invoiceInstallmentDff = new List<InvoiceInstallmentDffModel>()
                }
            };
            payload.invoiceLines = new List<InvoiceLineModel>
            {
                new InvoiceLineModel
                {
                    LineNumber = 1,
                    LineAmount = Convert.ToDecimal(2112.75),
                    invoiceDistributions = new List<InvoiceDistributionModel>
                    {
                        new InvoiceDistributionModel
                        {
                            DistributionLineNumber = 1,
                            DistributionLineType = "Item",
                            DistributionAmount = Convert.ToDecimal(2112.75),
                            DistributionCombination = "110-1339-819001-701-20101-999-999-999"
                        }
                    }
                },
                new InvoiceLineModel
                {
                    LineNumber = 2,
                    LineType = "Freight",
                    LineAmount = 100,
                    ProrateAcrossAllItemsFlag = true
                }
            };

            string url = "https://fa-exke-test-saasfaprod1.fa.ocs.oraclecloud.com/fscmRestApi/resources/11.13.18.05/invoices";
            string username = "elistec@jresources.com";
            string password = "Bky\\_J0x5A?9";

            using var client = new HttpClient();

            // Set up Basic Authentication
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            // Serialize payload to JSON
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            string jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload, options);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            Console.WriteLine("Payload is ready, begin to create the invoice");
            try
            {
                // Make the POST request
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Success! Response content:");
                    Console.WriteLine(responseContent);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error details:");
                    Console.WriteLine(errorContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Test()
        {
            // Define the request payload
            var payload = new
            {
                InvoiceNumber = "AND_Unmatched_Invoice_Test04",
                InvoiceCurrency = "USD",
                InvoiceAmount = 2212.75,
                InvoiceDate = "2019-02-01",
                BusinessUnit = "JRBML BU",
                Supplier = "MARMERO KARYA SEJAHTERA, PT",
                SupplierSite = "BITUNG",
                //Requester = null,
                InvoiceGroup = "01Feb2019",
                Description = "Office Supplies"
            };

            string url = "https://fa-exke-test-saasfaprod1.fa.ocs.oraclecloud.com/fscmRestApi/resources/11.13.18.05/invoices";
            string username = "elistec@jresources.com";
            string password = "Bky\\_J0x5A?9";

            using var client = new HttpClient();

            // Set up Basic Authentication
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            // Serialize payload to JSON
            string jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                // Make the POST request
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Success! Response content:");
                    Console.WriteLine(responseContent);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error details:");
                    Console.WriteLine(errorContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
        }
    }
}
