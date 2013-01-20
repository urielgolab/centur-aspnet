//
//  MisTurnosViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 10/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "MisTurnosViewController.h"
#import "SRVBusqueda.h"
#import "ProveedorDetailViewController.h"

@interface MisTurnosViewController ()

@end

@implementation MisTurnosViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.title = @"Mis Turnos";
        self.misTurnosConfirmados = [NSMutableArray array];
        self.misTurnosNoConfirmados = [NSMutableArray array];
        [self createNotification];
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
}

-(void)viewDidAppear:(BOOL)animated{
    [super viewDidAppear:animated];
    [self loadServicios];

}

-(void)loadServicios{
    Usuario* usuario = [SRVProfile GetInstance].currentUser;
    [[SRVBusqueda GetInstance] startsearchMisTurnos:usuario];
}

-(void)createNotification{
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(misTurnosOK:)
                                                 name:SERVICE_SERVICIOSMISTURNOS_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(misTurnosFailed:)
                                                 name:SERVICE_SERVICIOSMISTURNOS_FAILED
                                               object:nil];
}

-(void)misTurnosOK:(NSNotification*)notification{
    [self.misTurnosConfirmados removeAllObjects];
    [self.misTurnosNoConfirmados removeAllObjects];
    
    for(Turno *turno in notification.object) {
        if (turno.Confirmado) {
            [self.misTurnosConfirmados addObject:turno];
        }else{
            [self.misTurnosNoConfirmados addObject:turno];
        }
    }
    [self.tableView reloadData];
}


-(void)misTurnosFailed:(NSNotification*)notification{
    [[[UIAlertView alloc]initWithTitle:@"Error" message:@"No se pudo acceder a ssu Favoritos" delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles: nil]show];
    [self.navigationController popViewControllerAnimated:YES];
}


#pragma mark - Table view data source

- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section{
    if (section == 0) {
        return @"Turnos confirmados";
    }else{
        return @"Turnos pendientes de confirmacion";
    }
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    // Return the number of sections.
    return 2;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    // Return the number of rows in the section.
    if (section == 0) {
        return [self.misTurnosConfirmados count];
    }else{
        return [self.misTurnosNoConfirmados count];
    }
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleSubtitle reuseIdentifier:CellIdentifier];
    }
    Turno* turno;
    if (indexPath.section == 0) {
        turno= [self.misTurnosConfirmados objectAtIndex:indexPath.row];
    }else{
        turno= [self.misTurnosNoConfirmados objectAtIndex:indexPath.row];
    }
    cell.textLabel.text = [NSString stringWithFormat:@"%@ %@", turno.Fecha,turno.ServicioNombre ] ;
    cell.textLabel.textAlignment = UITextAlignmentLeft;
    cell.detailTextLabel.textAlignment = UITextAlignmentLeft;
    cell.detailTextLabel.text =  [NSString stringWithFormat:@"%@ - %@",turno.horaInicio,turno.horaFin ];
    return cell;
}

- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Return NO if you do not want the specified item to be editable.
    return YES;
}
 // Override to support editing the table view.
 - (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath
 {
     if (editingStyle == UITableViewCellEditingStyleDelete) {
         // Delete the row from the data source
         Turno* turno;
         if (indexPath.section == 0) {
             turno= [self.misTurnosConfirmados objectAtIndex:indexPath.row];
         }else{
             turno= [self.misTurnosNoConfirmados objectAtIndex:indexPath.row];
         }
         [[SRVBusqueda GetInstance]cancelarTurno:turno];
         
         if (indexPath.section == 0) {
            [self.misTurnosConfirmados removeObject:turno];
         }
         else{
             [self.misTurnosNoConfirmados removeObject:turno];
         }
         
         [tableView deleteRowsAtIndexPaths:@[indexPath] withRowAnimation:UITableViewRowAnimationFade];
     }
 }

#pragma mark - Table view delegate

-(NSIndexPath*)tableView:(UITableView *)tableView willSelectRowAtIndexPath:(NSIndexPath *)indexPath{
    Turno* turno;
    if (indexPath.section == 0) {
        turno= [self.misTurnosConfirmados objectAtIndex:indexPath.row];
    }else{
        turno= [self.misTurnosNoConfirmados objectAtIndex:indexPath.row];
    }
    Servicio* servicio = [[Servicio alloc]init];
    servicio.ID = turno.ServicioID;
    
    ProveedorDetailViewController * pd = [[ProveedorDetailViewController alloc]initWithNibName:@"ProveedorDetailViewController" bundle:nil andProveedor:servicio];
    
    [self.navigationController pushViewController:pd animated:YES];
    return nil;
}
    
    

@end
