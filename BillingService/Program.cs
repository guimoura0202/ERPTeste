using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using BillingService.Services;

var builder = WebApplication.CreateBuilder(args);

var firebaseConfig = builder.Configuration.GetSection("Firebase");
var projectId = firebaseConfig["ProjectId"];
var credentialPath = firebaseConfig["CredentialPath"];

var credential = GoogleCredential.FromFile(credentialPath);
FirestoreDb db = FirestoreDb.Create(projectId, new FirestoreClientBuilder { Credential = credential }.Build());

builder.Services.AddSingleton(db);

builder.Services.AddScoped<BillingRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
