﻿using api.Interfaces;
using api.Models;
using MongoDB.Driver;

namespace api.Services
{
    public class FillAnEmptyDb : IHostedService
    {
        private readonly IFileService _fileService;
        private readonly IDatasetService _datasetService;
        private readonly IModelService _modelService;
        private readonly IExperimentService _experimentService;
        private readonly IPredictorService _predictorService;


        public FillAnEmptyDb(IUserStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _fileService = new FileService(settings, mongoClient);
            _experimentService = new ExperimentService(settings, mongoClient);
            _datasetService = new DatasetService(settings, mongoClient, _experimentService);
            _modelService = new ModelService(settings, mongoClient);
            _predictorService = new PredictorService(settings, mongoClient);
        }



        //public void AddToEmptyDb()
        public Task StartAsync(CancellationToken cancellationToken)
        {


            if (_fileService.CheckDb())
            {

                FileModel file = new FileModel();

                string folderName = "UploadedFiles";
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName, "000000000000000000000000");
                var fullPath = Path.Combine(folderPath, "titanic.csv");

                file._id = "";
                file.type = ".csv";
                file.uploaderId = "000000000000000000000000";
                file.path = fullPath;
                file.date = DateTime.Now;

                _fileService.Create(file);



                Dataset dataset = new Dataset();

                dataset._id = "";
                dataset.uploaderId = "000000000000000000000000";
                dataset.name = "Titanik dataset(public)";
                dataset.description = "Titanik dataset";
                dataset.fileId = _fileService.GetFileId(fullPath);
                dataset.extension = ".csv";
                dataset.isPublic = true;
                dataset.accessibleByLink = true;
                dataset.dateCreated = DateTime.UtcNow;
                dataset.lastUpdated = DateTime.UtcNow;
                dataset.delimiter = ",";
                dataset.columnInfo = new[]
                {

                    new ColumnInfo( "PassengerId", true, 0, 446, 1, 891, 446, new string[]{ "1","599","588", "589", "590", "591" }, new int[] { 1, 1, 1, 1, 1, 1}, new float[] { 0.0011223345063626766f, 0.0011223345063626766f, 0.0011223345063626766f, 0.0011223345063626766f, 0.0011223345063626766f, 0.0011223345063626766f }, 223.5f, 668.5f ),
                    new ColumnInfo( "Survived", true, 0, 0.38383838534355164f, 0, 1, 0, new string[]{ "0", "1" }, new int[] { 549, 342}, new float[] { 0.6161616444587708f, 0.38383838534355164f}, 0f, 1f ),
                    new ColumnInfo( "Pclass", true, 0, 2.3086419105529785f, 1, 3, 3, new string[]{ "3", "1", "2" }, new int[] {491, 216, 184}, new float[] {0.5510662198066711f, 0.24242424964904785f, 0.2065095454454422f }, 2f, 3f ),
                    new ColumnInfo( "Name", false, 0, 0, 0, 0, 0, new string[]{"Braund, Mr. Owen Harris", "Boulos, Mr. Hanna", "Frolicher-Stehli, Mr. Maxmillian", "Gilinski, Mr. Eliezer", "Murdlin, Mr. Joseph", "Rintamaki, Mr. Matti"}, new int[] {1,1,1,1,1,1}, new float[] {0.0011223345063626766f, 0.0011223345063626766f, 0.0011223345063626766f, 0.0011223345063626766f, 0.0011223345063626766f, 0.0011223345063626766f }, 0f, 0f ),
                    new ColumnInfo( "Sex", false, 0, 0, 0, 0, 0, new string[]{ "male", "female" }, new int[] {577,314}, new float[] {0.6475870013237f, 0.35241302847862244f}, 0f,0f ),
                    new ColumnInfo( "Age", true, 177, 29.69911766052246f, 0.41999998688697815f, 80, 28, new string[]{ "nan", "24.0", "22.0", "18.0", "28.0", "30.0" }, new int[] {177,30,27,26,25,25}, new float[] {0.1986531913280487f,0.033670034259557724f,0.03030303120613098f,0.029180696234107018f,0.028058361262083054f,0.028058361262083054f}, 20.125f,38f ),
                    new ColumnInfo( "SibSp", true, 0, 0.523007869720459f, 0, 8, 0, new string[]{ "0", "1", "2", "3", "4", "3", "8" }, new int[] {608, 209, 28, 18, 16, 7}, new float[] {0.6823793649673462f, 0.23456789553165436f, 0.031425364315509796f, 0.020202020183205605f, 0.017957352101802826f, 0.007856341078877449f }, 0f, 1f ),
                    new ColumnInfo( "Parch", true, 0, 0.3815937042236328f, 0, 6, 0, new string[]{ "0", "1", "2", "5", "3", "4" }, new int[] { 678, 118, 80, 5, 5, 4}, new float[] {0.7609427571296692f, 0.13243547081947327f, 0.08978675305843353f, 0.005611672066152096f, 0.005611672066152096f, 0.0044893380254507065f }, 0f,0f ),
                    new ColumnInfo( "Ticket", false, 0, 0, 0, 0, 0, new string[]{ "347082", "CA. 2343", "1601", "3101295", "CA 2144", "347088" }, new int[] {7, 7, 7, 6, 6, 6}, new float[] {0.007856341078877449f, 0.007856341078877449f, 0.007856341078877449f, 0.006734006572514772f, 0.006734006572514772f, 0.006734006572514772f}, 0f,0f ),
                    new ColumnInfo( "Fare", true, 0, 32.20420837402344f, 0, 512.3292236328125f, 14.45419979095459f, new string[]{ "8.05", "13.0", "7.8958", "7.75", "26.0", "10.5"}, new int[] {43, 42, 38, 34, 31, 24}, new float[] {0.04826038330793381f, 0.047138046473264694f, 0.04264871031045914f, 0.03815937042236328f, 0.03479236736893654f, 0.02693602629005909f }, 7.910399913787842f,31f ),
                    new ColumnInfo( "Cabin", false, 687, 0, 0, 0, 0, new string[]{ "B96 B98", "G6", "C23 C25 C27", "C22 C26", "F33", "F2" }, new int[] {4, 4, 4, 3, 3, 3}, new float[] {0.0044893380254507065f, 0.0044893380254507065f, 0.0044893380254507065f, 0.003367003286257386f, 0.003367003286257386f, 0.003367003286257386f }, 0f,0f ),
                    new ColumnInfo( "Embarked", false, 2, 0, 0, 0, 0, new string[]{ "S", "C", "Q" }, new int[] {644, 168, 77}, new float[] {0.7227833867073059f, 0.18855218589305878f, 0.08641975373029709f}, 0f,0f ),
                };
                dataset.rowCount = 891;
                dataset.nullCols = 3;
                dataset.nullRows = 689;
                dataset.isPreProcess = true;
                dataset.cMatrix = new float[12][];
                dataset.cMatrix[0] = new float[] { 1, -0.005007f, -0.035144f, -0.038559f, 0.042939f, 0.036847f, -0.057527f, -0.001652f, -0.056554f, 0.012658f, -0.035077f, 0.013083f };
                dataset.cMatrix[1] = new float[] { -0.0050066607f, 1f, -0.33848104f, -0.057343315f, -0.54335135f, -0.077221096f, -0.0353225f, 0.08162941f, -0.16454913f, 0.25730652f, -0.25488788f, -0.16351666f };
                dataset.cMatrix[2] = new float[] { -0.035143994f, -0.33848104f, 1f, 0.052830875f, 0.13190049f, -0.369226f, 0.083081365f, 0.018442672f, 0.31986925f, -0.54949963f, 0.6841206f, 0.15711245f };
                dataset.cMatrix[3] = new float[] { -0.038558863f, -0.057343315f, 0.052830875f, 1f, 0.020313991f, 0.06258293f, -0.017230336f, -0.04910539f, 0.047348045f, -0.049172707f, 0.061959103f, -0.0045570857f };
                dataset.cMatrix[4] = new float[] { 0.04293888f, -0.54335135f, 0.13190049f, 0.020313991f, 1f, 0.093253575f, -0.11463081f, -0.24548896f, 0.059371985f, -0.18233283f, 0.09668117f, 0.104057096f };
                dataset.cMatrix[5] = new float[] { 0.036847197f, -0.077221096f, -0.369226f, 0.06258293f, 0.093253575f, 1f, -0.30824676f, -0.18911926f, -0.07593447f, 0.09606669f, -0.2523314f, -0.02525195f };
                dataset.cMatrix[6] = new float[] { -0.057526834f, -0.0353225f, 0.083081365f, -0.017230336f, -0.11463081f, -0.30824676f, 1f, 0.4148377f, 0.079461284f, 0.15965104f, 0.043592583f, 0.06665404f };
                dataset.cMatrix[7] = new float[] { -0.0016520123f, 0.08162941f, 0.018442672f, -0.04910539f, -0.24548896f, -0.18911926f, 0.4148377f, 1f, 0.020003473f, 0.21622494f, -0.02832425f, 0.038322248f };
                dataset.cMatrix[8] = new float[] { -0.056553647f, -0.16454913f, 0.31986925f, 0.047348045f, 0.059371985f, -0.07593447f, 0.079461284f, 0.020003473f, 1f, -0.013885464f, 0.24369627f, -0.0060414947f };
                dataset.cMatrix[9] = new float[] { 0.012658219f, 0.25730652f, -0.54949963f, -0.049172707f, -0.18233283f, 0.09606669f, 0.15965104f, 0.21622494f, -0.013885464f, 1f, -0.5033555f, -0.22122625f };
                dataset.cMatrix[10] = new float[] { -0.035077456f, -0.25488788f, 0.6841206f, 0.061959103f, 0.09668117f, -0.2523314f, 0.043592583f, -0.02832425f, 0.24369627f, -0.5033555f, 1f, 0.19320504f };
                dataset.cMatrix[11] = new float[] { 0.013083069f, -0.16351666f, 0.15711245f, -0.0045570857f, 0.104057096f, -0.02525195f, 0.06665404f, 0.038322248f, -0.0060414947f, -0.22122625f, 0.19320504f, 1f };

                _datasetService.Create(dataset);


                Model model = new Model();

                model._id = "";
                model.uploaderId = "000000000000000000000000";
                model.name = "Titanik model";
                model.description = "Model Titanik";
                model.dateCreated = DateTime.Now;
                model.lastUpdated = DateTime.Now;
                model.type = "binarni-klasifikacioni";
                model.optimizer = "Adam";
                model.lossFunction = "binary_crossentropy";
                model.hiddenLayers = 4;
                model.batchSize = "64";
                model.learningRate = "1";
                model.outputNeurons = 0;
                model.layers = new[]
                {
                    new Layer ( 0,"sigmoid", 3,"l1", 1f ),
                    new Layer ( 1,"sigmoid", 3,"l1", 1f ),
                    new Layer ( 2,"sigmoid", 3,"l1", 1f ),
                    new Layer ( 3,"sigmoid", 3,"l1", 1f ),
                };
                model.outputLayerActivationFunction = "sigmoid";
                model.metrics = new string[] { };
                model.epochs = 50;
                model.randomOrder = true;
                model.randomTestSet = true;
                model.randomTestSetDistribution = 0.1f;
                model.isPublic = true;
                model.accessibleByLink = true;
                model.validationSize = 0.1f;//proveri

                _modelService.Create(model);


                Experiment experiment = new Experiment();

                experiment._id = "";
                experiment.name = "Titanik eksperiment (binarno-klasifikacioni)";
                experiment.description = "Binarno klasifikacioni, label";
                experiment.type = "binarni-klasifikacioni";
                experiment.ModelIds = new string[] { }.ToList();
                experiment.datasetId = _datasetService.GetDatasetId(dataset.fileId);
                experiment.uploaderId = "000000000000000000000000";
                experiment.inputColumns = new string[] { "Survived", "Pclass", "Sex", "Age", "SibSp", "Parch", "Ticket", "Fare", "Embarked" };
                experiment.outputColumn = "Survived";
                experiment.nullValues = "delete_rows";
                experiment.dateCreated = DateTime.Now;
                experiment.lastUpdated = DateTime.Now;
                experiment.nullValuesReplacers = new[]
                {
                    new NullValues ("Survived", "delete_rows", ""),
                    new NullValues ("Pclass", "delete_rows", ""),
                    new NullValues ("Sex", "delete_rows", ""),
                    new NullValues ("Age", "delete_rows", ""),
                    new NullValues ("SibSp", "delete_rows", ""),
                    new NullValues ("Parch", "delete_rows", ""),
                    new NullValues ("Ticket", "delete_rows", ""),
                    new NullValues ("Fare", "delete_rows", ""),
                    new NullValues ("Embarked", "delete_rows", "")
                };
                experiment.encodings = new[]
                {
                    new ColumnEncoding( "PassengerId", "label" ),
                    new ColumnEncoding( "Survived", "label" ),
                    new ColumnEncoding( "Pclass", "label" ),
                    new ColumnEncoding( "Name", "label" ),
                    new ColumnEncoding( "Sex", "label" ),
                    new ColumnEncoding( "Age", "label" ),
                    new ColumnEncoding( "SibSp", "label" ),
                    new ColumnEncoding( "Parch", "label" ),
                    new ColumnEncoding( "Ticket", "label" ),
                    new ColumnEncoding( "Fare", "label" ),
                    new ColumnEncoding( "Cabin", "label" ),
                    new ColumnEncoding("Embarked", "label" )
                };
                experiment.columnTypes = new string[] { "numerical", "categorical", "categorical", "categorical", "categorical", "numerical", "categorical", "numerical", "categorical", "numerical", "categorical", "categorical" };

                _experimentService.Create(experiment);

                /*
                Predictor predictor = new Predictor();
                
                predictor._id = "";
                predictor.uploaderId = "000000000000000000000000";
                predictor.inputs = new string[] { "Embarked" };
                predictor.output = "Survived";
                predictor.isPublic = true;
                predictor.accessibleByLink = true;
                predictor.dateCreated = DateTime.Now;
                predictor.experimentId = experiment._id;//izmeni experiment id
                predictor.modelId = _modelService.getModelId("000000000000000000000000");
                predictor.h5FileId = ;
                predictor.metrics = new Metric[] { };
                predictor.finalMetrics = new Metric[] { };

                _predictorService.Create(predictor);*/

                //--------------------------------------------------------------------

                file = new FileModel();

                fullPath = Path.Combine(folderPath, "diamonds.csv");
                file._id = "";
                file.type = ".csv";
                file.uploaderId = "000000000000000000000000";
                file.path = fullPath;
                file.date = DateTime.Now;

                _fileService.Create(file);


                dataset = new Dataset();

                dataset._id = "";
                dataset.uploaderId = "000000000000000000000000";
                dataset.name = "Diamonds dataset";
                dataset.description = "Diamonds dataset(public)";
                dataset.fileId = _fileService.GetFileId(fullPath);
                dataset.extension = ".csv";
                dataset.isPublic = true;
                dataset.accessibleByLink = true;
                dataset.dateCreated = DateTime.Now;
                dataset.lastUpdated = DateTime.Now;
                dataset.delimiter = ",";
                dataset.columnInfo = new[]
                 {
                    new ColumnInfo( "Unnamed: 0", true, 0, 26969.5f, 0, 53939, 26969.5f, new string[]{ "0", "35977", "35953", "35954", "35955", "35956" }, new int[] {1,1,1,1,1,1}, new float[] {0.000018539118173066527f, 0.000018539118173066527f, 0.000018539118173066527f, 0.000018539118173066527f, 0.000018539118173066527f, 0.000018539118173066527f}, 13484.75f,40454.25f ),
                    new ColumnInfo( "carat", true, 0, 0.7979397773742676f, 0.20000000298023224f, 5.010000228881836f, 0.699999988079071f, new string[]{ "0.3", "0.31", "1.01", "0.7", "0.32", "1.0" }, new int[] {2604, 2249, 2242, 1981, 1840, 1558}, new float[] {0.04827586188912392f, 0.04169447720050812f, 0.0415647029876709f, 0.03672599047422409f, 0.034111976623535156f, 0.02888394519686699f}, 0.4000000059604645f,1.0399999618530273f ),
                    new ColumnInfo( "cut", false, 0, 0, 0, 0, 0, new string[]{ "Ideal", "Premium", "Very Good", "Good", "Fair" }, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "color", false, 0, 0, 0, 0, 0, new string[]{"G", "E", "F", "H", "D", "I", "I", "J"}, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "clarity", false, 0, 0, 0, 0, 0, new string[]{ "SI1", "VS2","SI2", "VS1", "VVS2", "VVS1", "IF", "I1"  }, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "depth", true, 0, 61.74940490722656f, 43, 79, 61.79999923706055f, new string[]{ }, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "table", true, 0, 57.457183837890625f, 43, 95, 57, new string[]{ }, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "price", true, 0, 3932.7998046875f, 326, 18823, 2401, new string[]{ }, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "x", true, 0, 5.731157302856445f, 0, 10.739999771118164f, 5.699999809265137f, new string[]{  }, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "y", true, 0, 5.73452615737915f, 0, 58.900001525878906f, 5.710000038146973f, new string[]{ }, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "z", true, 0, 3.538733720779419f, 0, 31.799999237060547f, 3.5299999713897705f, new string[]{ }, new int[] {}, new float[] {}, 0.01f,0.1f )
                    };
                dataset.rowCount = 53940;
                dataset.nullCols = 0;
                dataset.nullRows = 0;
                dataset.isPreProcess = true;
                dataset.cMatrix = new float[11][];
                dataset.cMatrix[0] = new float[] { 1f, -0.005006660707294941f, -0.03514399379491806f, -0.03855886310338974f, 0.04293888062238693f, 0.03684719651937485f };


                _datasetService.Create(dataset);



                model = new Model();

                model._id = "";
                model.uploaderId = "000000000000000000000000";
                model.name = "Diamonds model";
                model.description = "Diamonds model";
                model.dateCreated = DateTime.Now;
                model.lastUpdated = DateTime.Now;
                model.type = "regresioni";
                model.optimizer = "Adam";
                model.lossFunction = "mean_absolute_error";
                model.hiddenLayers = 4;
                model.batchSize = "8";
                model.outputNeurons = 0;
                model.outputLayerActivationFunction = "relu";
                model.metrics = new string[] { };
                model.epochs = 5;
                model.isPublic = true;
                model.accessibleByLink = true;
                model.validationSize = 0.1f;//proveri

                _modelService.Create(model);


                experiment = new Experiment();

                experiment._id = "";
                experiment.name = "Diamonds eksperiment";
                experiment.description = "Diamonds eksperiment";
                experiment.ModelIds = new string[] { }.ToList();
                experiment.datasetId = _datasetService.GetDatasetId(dataset.fileId);
                experiment.uploaderId = "000000000000000000000000";
                experiment.inputColumns = new string[] { "Unnamed: 0", "carat", "cut", "color", "clarity", "depth", "table", "x", "y", "z", "price" };
                experiment.outputColumn = "price";
                experiment.dateCreated = DateTime.Now;
                experiment.lastUpdated = DateTime.Now;
                experiment.nullValues = "delete_rows";
                experiment.nullValuesReplacers = new NullValues[] { };
                experiment.encodings = new[]
                 {
                    new ColumnEncoding( "Unnamed: 0", "label" ),
                    new ColumnEncoding( "carat", "label" ),
                    new ColumnEncoding( "cut", "label" ),
                    new ColumnEncoding( "color", "label" ),
                    new ColumnEncoding( "clarity", "label" ),
                    new ColumnEncoding( "depth", "label" ),
                    new ColumnEncoding( "table", "label" ),
                    new ColumnEncoding( "price", "label" ),
                    new ColumnEncoding( "x", "label" ),
                    new ColumnEncoding( "y", "label" ),
                    new ColumnEncoding( "z", "label" )
                };
                experiment.columnTypes = new string[] { "categorical", "numerical", "numerical", "categorical", "categorical", "categorical", "numerical", "numerical", "numerical", "numerical", "numerical" };

                _experimentService.Create(experiment);
                /*
                predictor._id = "";
                predictor.uploaderId = "000000000000000000000000";
                predictor.inputs = new string[] { "Unnamed: 0", "carat", "cut", "color", "clarity", "depth", "table", "x", "y", "z" };
                predictor.output = "price";
                predictor.isPublic = true;
                predictor.accessibleByLink = true;
                predictor.dateCreated = DateTime.Now;
                predictor.experimentId = experiment._id;//izmeni experiment id
                predictor.modelId = _modelService.getModelId("000000000000000000000000");
                predictor.h5FileId = ;
                predictor.metrics = new Metric[] { }
                predictor.finalMetrics = new Metric[] { };
                
                 _predictorService.Create(predictor);
                 */

                //--------------------------------------------------------------------

                file = new FileModel();

                fullPath = Path.Combine(folderPath, "iris.csv");
                file._id = "";
                file.type = ".csv";
                file.uploaderId = "000000000000000000000000";
                file.path = fullPath;
                file.date = DateTime.Now;

                _fileService.Create(file);


                dataset = new Dataset();

                dataset._id = "";
                dataset.uploaderId = "000000000000000000000000";
                dataset.name = "Iris dataset";
                dataset.description = "Iris dataset(public) ";
                dataset.fileId = _fileService.GetFileId(fullPath);
                dataset.extension = ".csv";
                dataset.isPublic = true;
                dataset.accessibleByLink = true;
                dataset.dateCreated = DateTime.Now;
                dataset.lastUpdated = DateTime.Now;
                dataset.delimiter = ",";
                dataset.columnInfo = new[]
                  {
                    new ColumnInfo( "sepal_length", true, 0, 5.8433332443237305f, 4.300000190734863f, 7.900000095367432f, 5.800000190734863f, new string[]{ }, new int[] {}, new float[] {}, 0.01f, 0.1f ),
                    new ColumnInfo( "sepal_width", true, 0, 3.053999900817871f, 2, 4.400000095367432f, 3, new string[]{ }, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "petal_length", true, 0, 3.758666753768921f, 1, 6.900000095367432f, 4.349999904632568f, new string[]{ }, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "petal_width", true, 0, 1.1986666917800903f, 0.10000000149011612f, 2.5f, 1.2999999523162842f, new string[]{}, new int[] {}, new float[] {}, 0.01f,0.1f ),
                    new ColumnInfo( "class", false, 0, 0, 0, 0, 0, new string[]{ "Iris-setosa", "Iris-versicolor", "Iris-virginica" }, new int[] {}, new float[] {}, 0.01f,0.1f ),
                };
                dataset.nullCols = 150;
                dataset.nullRows = 0;
                dataset.isPreProcess = true;
                dataset.cMatrix = new float[11][];
                dataset.cMatrix[0] = new float[] { 1f, -0.005006660707294941f, -0.03514399379491806f, -0.03855886310338974f, 0.04293888062238693f, 0.03684719651937485f };


                _datasetService.Create(dataset);


                model = new Model();

                model._id = "";
                model.uploaderId = "000000000000000000000000";
                model.name = "Model Iris";
                model.description = "Model Iris";
                model.dateCreated = DateTime.Now;
                model.lastUpdated = DateTime.Now;
                model.type = "multi-klasifikacioni";
                model.optimizer = "Adam";
                model.lossFunction = "sparse_categorical_crossentropy";
                model.hiddenLayers = 3;
                model.batchSize = "64";
                model.outputNeurons = 0;
                model.outputLayerActivationFunction = "softmax";
                model.metrics = new string[] { };
                model.epochs = 1;
                model.isPublic = true;
                model.accessibleByLink = true;
                model.validationSize = 0.1f;//proveri

                _modelService.Create(model);


                experiment = new Experiment();

                experiment._id = "";
                experiment.name = "Iris eksperiment";
                experiment.description = "Iris eksperiment";
                experiment.ModelIds = new string[] { }.ToList();
                experiment.datasetId = _datasetService.GetDatasetId(dataset.fileId);
                experiment.uploaderId = "000000000000000000000000";
                experiment.inputColumns = new string[] { "sepal_length", "sepal_width", "petal_length", "petal_width", "class" };
                experiment.outputColumn = "class";
                experiment.dateCreated = DateTime.Now;
                experiment.lastUpdated = DateTime.Now;
                experiment.nullValues = "delete_rows";
                experiment.nullValuesReplacers = new NullValues[] { };
                experiment.encodings = new[]
                 {
                    new ColumnEncoding( "sepal_length", "label" ),
                    new ColumnEncoding("sepal_width", "label" ),
                    new ColumnEncoding( "petal_length", "label" ),
                    new ColumnEncoding( "petal_width", "label" ),
                    new ColumnEncoding( "class", "label" )
                };
                experiment.columnTypes = new string[] { "categorical", "numerical", "numerical", "numerical", "categorical" };


                _experimentService.Create(experiment);
                /*
                predictor._id = "";
                predictor.uploaderId = "000000000000000000000000";
                predictor.inputs = new string[] { "sepal_length", "sepal_width", "petal_length", "petal_width" };
                predictor.output = "class";
                predictor.isPublic = true;
                predictor.accessibleByLink = true;
                predictor.dateCreated = DateTime.Now;
                predictor.experimentId = experiment._id;//izmeni experiment id
                predictor.modelId = _modelService.getModelId("000000000000000000000000");
                predictor.h5FileId = ;
                predictor.metrics = new Metric[] { };
                predictor.finalMetrics = new Metric[] { };
                
                 _predictorService.Create(predictor);
                 */

            }


            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}
