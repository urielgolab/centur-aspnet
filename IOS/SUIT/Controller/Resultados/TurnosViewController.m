//
//  TurnosViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 05/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "TurnosViewController.h"
#import "SRVBusqueda.h"
#import "SRVProfile.h"
#import "MercadoPagoViewController.h"
#define MERCADOPAGO 1

@interface TurnosViewController ()

@end

@implementation TurnosViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        [self createNotification];
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];

    // Uncomment the following line to preserve selection between presentations.
    // self.clearsSelectionOnViewWillAppear = NO;
 
    // Uncomment the following line to display an Edit button in the navigation bar for this view controller.
    // self.navigationItem.rightBarButtonItem = self.editButtonItem;
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(void)createNotification{
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(reservarOK:)
                                                 name:SERVICE_RESERVARTURNOSSERVICIO_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(reservarFailed:)
                                                 name:SERVICE_RESERVARTURNOSSERVICIO_FAILED
                                               object:nil];
  
}

-(void)reservarFailed:(NSNotification*) notification{
     [[[UIAlertView alloc]initWithTitle:@"Fallo la Reserva de Turno" message:nil delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles: nil]show];
}


-(void)reservarOK:(NSNotification*) notification{

    NSString* text = nil;
    Turno *turno = notification.object;
    if (self.servicio.NecesitaConfirmacion) {
        text = @"Recuerde que el turno esta pendiente de confirmacion por parte del proveedor del servicio";
    }
    
    [[[UIAlertView alloc]initWithTitle:@"Turno Reservado" message:text delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles: nil]show];
    
    
    [self.navigationController popViewControllerAnimated:YES];

}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    // Return the number of sections.
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    // Return the number of rows in the section.
    return [self.turnos count];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleSubtitle reuseIdentifier:CellIdentifier];
    }
    cell.textLabel.text = [[self.turnos objectAtIndex:indexPath.row] Fecha] ;
    cell.textLabel.textAlignment = UITextAlignmentLeft;
    cell.detailTextLabel.textAlignment = UITextAlignmentLeft;
    cell.detailTextLabel.text =  [NSString stringWithFormat:@"%@ - %@",[[self.turnos objectAtIndex:indexPath.row] horaInicio],[[self.turnos objectAtIndex:indexPath.row] horaFin] ];

    // Configure the cell...
    
    return cell;
}


#pragma mark - Table view delegate

-(NSIndexPath*)tableView:(UITableView *)tableView willSelectRowAtIndexPath:(NSIndexPath *)indexPath{
    Turno* turno = [self.turnos objectAtIndex:indexPath.row];
    Usuario* usuario = [SRVProfile GetInstance].currentUser;
    
    if (!usuario) {
        [[[UIAlertView alloc]initWithTitle:@"Error" message:@"Debe estar logeado para poder reservar un turno" delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles: nil]show];
        //TODO
        //Levantar la vista de logiarse
        return nil;
    }
    
    if (self.servicio.MercadoPago) {
        UIAlertView *alert = [[UIAlertView alloc]initWithTitle:@"Mercado Pago" message:@"El servicio solicita una reserva previa" delegate:self cancelButtonTitle:@"Cancelar" otherButtonTitles: @"Aceptar", nil];
        alert.tag = MERCADOPAGO;
        selectedTurno = turno;
        [alert show];
        return nil;
    }
    
    [[SRVBusqueda GetInstance] reservarTurno:turno servicio:self.servicio usuario:usuario];
    
    return nil;
}

#pragma mark Delegate

- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex{
    
    if (alertView.tag == MERCADOPAGO && alertView.cancelButtonIndex != buttonIndex) {
        //Se acepto mercado pago
        MercadoPagoViewController* mp = [[MercadoPagoViewController alloc] initWithNibName:@"MercadoPagoViewController" bundle:nil andServicio:self.servicio andTurno:selectedTurno];
       UINavigationController*nv= [[UINavigationController alloc]initWithRootViewController:mp];
        [self.navigationController presentModalViewController:nv animated:YES];
    }
}



@end
