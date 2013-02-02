//
//  ProveedorDetailViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "ProveedorDetailViewController.h"
#import "ProveedorMapaViewController.h"
#import "SRVBusqueda.h"
#import "FechaPikerViewController.h"
#import "TurnosViewController.h"
#import "GruposDeServicioViewController.h"
#import "UIImageView+AFNetworking.h"


#define BASE_IMAGE @"http://centur.ugserver.com.ar/UrielWeb/Images/publicaciones/%@"

@interface ProveedorDetailViewController ()

@end

@implementation ProveedorDetailViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andProveedor:(Servicio*)aProveedor
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        proveedor = aProveedor;
        
        self.title = proveedor.Nombre;
       
        [self createNotification];
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    [self loadData];
    // Do any additional setup after loading the view from its nib.
}

- (void)viewDidUnload
{
    thumbsImage = nil;
    direccionLabel = nil;
    descripcionTextView = nil;
    pedirTurno = nil;
    mapaButton = nil;
    nombreLabel = nil;
    verGruposButton = nil;
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

-(void)createNotification{
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(servicioOK:)
                                                 name:SERVICE_GETSERVICIODETAIL_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(servicioFailed:)
                                                 name:SERVICE_GETSERVICIODETAIL_FAILED
                                               object:nil];
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(turnoOK:)
                                                 name:SERVICE_TURNOSSERVICIO_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(turnoFailed:)
                                                 name:SERVICE_TURNOSSERVICIO_FAILED
                                               object:nil];
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(agregarFavoritoOK:)
                                                 name:SERVICE_AGREGARFAVORITO_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(agregarFavoritoFailed:)
                                                 name:SERVICE_AGREGARFAVORITO_FAILED
                                               object:nil];
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(quitarFavoritoOK:)
                                                 name:SERVICE_QUITARFAVORITO_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(quitarFavoritoFailed:)
                                                 name:SERVICE_QUITARFAVORITO_FAILED
                                               object:nil];

}

-(void)agregarFavoritoOK:(NSNotification*)notification{
    [self loadData];
}

-(void)agregarFavoritoFailed:(NSNotification*)notification{
    [self loadData];    
}

-(void)quitarFavoritoOK:(NSNotification*)notification{
    [self loadData];
}

-(void)quitarFavoritoFailed:(NSNotification*)notification{
    [self loadData];
}


-(void)turnoOK:(NSNotification*)notification{
    TurnosViewController* tvc = [[TurnosViewController alloc]initWithNibName:@"TurnosViewController" bundle:nil];
    tvc.turnos = notification.object;
    tvc.servicio = proveedor;
    [self.navigationController pushViewController:tvc animated:YES];

}

-(void)turnoFailed:(NSNotification*)notification{
    [[[UIAlertView alloc]initWithTitle:nil message:@"No hay turnos Disponibles" delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles: nil]show];
}

-(void)servicioOK:(NSNotification*)notification{
    [self loadData];
}

-(void)servicioFailed:(NSNotification*)notification{
    
    [[[UIAlertView alloc]initWithTitle:nil message:@"Fallo obtener detalle del Servicio" delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles: nil]show];
    [self.navigationController popToRootViewControllerAnimated:YES];
}

-(void)loadData{
    //thumbsImage.image = [UIImage imageNamed:@"stationimage.png"];
    [thumbsImage setImageWithURL: [NSURL URLWithString:[NSString stringWithFormat:BASE_IMAGE,proveedor.Imagen]]placeholderImage:[UIImage imageNamed:@"logoGrande.png"]];
    
    nombreLabel.text = proveedor.Nombre;
    direccionLabel.text = proveedor.Direccion;
    direccionLabel.numberOfLines = 0;

    [direccionLabel sizeThatFits:CGSizeMake(direccionLabel.frame.size.width, 0)];
    descripcionTextView.text = proveedor.Descripcion;
    mapaButton.hidden =  !proveedor.isCoordinated;
    verGruposButton.hidden = YES;
    pedirTurno.hidden = YES;
    if ([SRVProfile GetInstance].currentUser) {
        verGruposButton.hidden = NO;
        pedirTurno.hidden = !proveedor.PuedePedirTurno;

        if (proveedor.EsFavorito ) {
            //esfavorito
            self.navigationItem.rightBarButtonItem = [[UIBarButtonItem alloc]initWithBarButtonSystemItem:UIBarButtonSystemItemStop target:self action:@selector(quitarFavoritoTouched)];
        }else{
            //No es favorito
            self.navigationItem.rightBarButtonItem = [[UIBarButtonItem alloc]initWithBarButtonSystemItem:UIBarButtonSystemItemAdd target:self action:@selector(agregarFavoritoTouched)];
        }
    }
}

-(void)viewDidAppear:(BOOL)animated{
    [super viewDidAppear:animated];
    [[SRVBusqueda GetInstance] startSearchForProvedorDetail:proveedor];

}


- (IBAction)pedirTurnoTouch:(UIButton *)sender {
    FechaPikerViewController* fecha = [[FechaPikerViewController alloc]initWithNibName:@"FechaPikerViewController" bundle:nil];
    
    fecha.searchBlock = ^(NSDate* date){
        [[SRVBusqueda GetInstance]buscarTurnosPara:proveedor paraDia:date];
    };
    
    fecha.minunDate = [NSDate dateWithTimeIntervalSinceNow: [proveedor.MinOffset intValue]*60*60*24 ];
    fecha.maxDate = [NSDate dateWithTimeIntervalSinceNow: [proveedor.MaxOffset intValue]*60*60*24 ];
    
    UINavigationController* nc = [[UINavigationController alloc]initWithRootViewController:fecha];
    [self.navigationController presentModalViewController:nc animated:YES];
    
}

- (IBAction)mapTouched:(UIButton *)sender {
    ProveedorMapaViewController *pm = [[ProveedorMapaViewController alloc]initWithNibName:@"ProveedorMapaViewController" bundle:nil andProveedor:proveedor];
    [self.navigationController pushViewController:pm animated:YES];
}

-(void)agregarFavoritoTouched{
    if ([SRVProfile GetInstance].currentUser){
        [[SRVBusqueda GetInstance] agregarAfavoritos:proveedor usuario: [SRVProfile GetInstance].currentUser];
    }
}

-(void)quitarFavoritoTouched{
    //[SRVBusqueda GetInstance]
    if ([SRVProfile GetInstance].currentUser){
        [[SRVBusqueda GetInstance] quitarDefavoritos:proveedor usuario: [SRVProfile GetInstance].currentUser];
    }
}

- (IBAction)verGrupos:(UIButton *)sender {
    GruposDeServicioViewController *gp = [[GruposDeServicioViewController alloc]initWithNibName:@"GruposDeServicioViewController" bundle:nil andServicio:proveedor];
    [self.navigationController pushViewController:gp animated:YES];
    
}
@end
