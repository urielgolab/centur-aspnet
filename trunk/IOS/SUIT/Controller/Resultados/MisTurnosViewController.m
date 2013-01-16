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
        [self createNotification];
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
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
    self.misTurnos = notification.object;
    [self.tableView reloadData];
}


-(void)misTurnosFailed:(NSNotification*)notification{
    
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
    return [self.misTurnos count];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleSubtitle reuseIdentifier:CellIdentifier];
    }
    Turno* turno = [self.misTurnos objectAtIndex:indexPath.row];
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
         Turno* turno = [self.misTurnos objectAtIndex:indexPath.row];
         [[SRVBusqueda GetInstance]cancelarTurno:turno];
         NSMutableArray *array = [self.misTurnos mutableCopy];
         [array removeObject:turno];
         self.misTurnos = [NSArray arrayWithArray: array];
         [tableView deleteRowsAtIndexPaths:@[indexPath] withRowAnimation:UITableViewRowAnimationFade];
     }
 }

#pragma mark - Table view delegate

-(NSIndexPath*)tableView:(UITableView *)tableView willSelectRowAtIndexPath:(NSIndexPath *)indexPath{
    Turno* turno = [self.misTurnos objectAtIndex:indexPath.row];
    Servicio* servicio = [[Servicio alloc]init];
    servicio.ID = turno.ServicioID;
    
    ProveedorDetailViewController * pd = [[ProveedorDetailViewController alloc]initWithNibName:@"ProveedorDetailViewController" bundle:nil andProveedor:servicio];
    
    [self.navigationController pushViewController:pd animated:YES];
    return nil;
}
    
    

@end
