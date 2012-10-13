//
//  ProveedorDetailViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "ProveedorDetailViewController.h"
#import "ProveedorMapaViewController.h"

@interface ProveedorDetailViewController ()

@end

@implementation ProveedorDetailViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andProveedor:(Servicio*)aProveedor
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        proveedor = aProveedor;
        self.title = proveedor.nombre;
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
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
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

-(void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    thumbsImage.image = [UIImage imageNamed:@"stationimage.png"];
    nombreLabel.text = proveedor.nombre;
    direccionLabel.text = proveedor.direccion;
    descripcionTextView.text = proveedor.descripcion;
    mapaButton.hidden =  !proveedor.isCoordinated;
}
- (IBAction)pedirTurnoTouch:(UIButton *)sender {
    
}

- (IBAction)mapTouched:(UIButton *)sender {
    ProveedorMapaViewController *pm = [[ProveedorMapaViewController alloc]initWithNibName:@"ProveedorMapaViewController" bundle:nil andProveedor:proveedor];
    [self.navigationController pushViewController:pm animated:YES];
}


@end
