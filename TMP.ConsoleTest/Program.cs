

//using TMP.aplication.commons.response.api;
//using TMP.aplication.commons.response.chatGpt;
//using TMP.aplication.dto;
//using TMP.aplication.mappings;
//using TMP.infraestructure.api;
//using TMP.infraestructure.webScraping.chatGpt;
//using TPM.domain.entities;

//LoadChatGptConfig conf = new LoadChatGptConfig();
//var content = conf.LoadJsonConfig(@"C:\\MiDirectorioDeCapturas\rezize.png");

//ApiCrudBase api = new ApiCrudBase();

//ApiResponse res = await api.Post("https://api.openai.com/v1/chat/completions", content);

//ProductDtoMap map = new ProductDtoMap();
//ProductDto pro = map.MapTo(res.Response.choices[0].message.content);

//Console.WriteLine(pro.Descripcion);
//Console.WriteLine(pro.PrecioOriginal);
//Console.WriteLine(pro.Descuento);
//Console.WriteLine(pro.Precio);


//////////////////////////////////////////////////////////////////////////////////////////////////
//using TMP.infraestructure.webScraping;

//CaptureUrl cap = new CaptureUrl();

//var res =await  cap.CaptureImgFromUrl("https://shoppremiumoutlets.com/products/mens-adidas-aeroready-designed-to-move-feelready-sport-tee?crpid=7102001512508");


//Console.WriteLine(res.Message);
//Console.WriteLine(res.Status);
//Console.WriteLine(res.Path);
///////////////////////////////////////////////////////////////////////////////////////////////////
//using TMP.aplication.contracts.useCase.facades;
//using TMP.aplication.useCases.imageTrack.basic;
//using TMP.aplication.useCases.imageTrack.facade;
//using TMP.infraestructure.persistence;
//using TMP.infraestructure.Repositories;
//using TPM.domain.entities;

//DbContextTMP dbContextTMP = new DbContextTMP();
//ImageTrack image = new ImageTrack() { email = "facade", price = 2334534, url = "asdfgwerdfda" };

//ImageTrackRepository imageRepository = new ImageTrackRepository(dbContextTMP);

//UseCaseCreateImageTrack USE = new UseCaseCreateImageTrack(imageRepository);
//UseCaseDeleteImageTrack delete = new UseCaseDeleteImageTrack(imageRepository);
//UseCaseGetAllImageTrack all = new UseCaseGetAllImageTrack(imageRepository);
//UseCaseGetImageTrack get = new UseCaseGetImageTrack(imageRepository);
//UseCaseUpdateImageTrack UP = new UseCaseUpdateImageTrack(imageRepository);

//IImageTrackFacade _facade = new FacadeUseCasesImageTrack(USE,delete,UP,all,get);
//var res = await _facade.CreateImageTrack(image);

//Console.WriteLine(res.Message);
//Console.WriteLine(res.Status);
//Console.WriteLine(res.Data);

Console.WriteLine("hola");
