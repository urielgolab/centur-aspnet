//
//  GruposDeServicioViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 15/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "GruposDeServicioViewController.h"
#import "ProvedoresDeGrupoViewController.h"

@interface GruposDeServicioViewController ()

@end

@implementation GruposDeServicioViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andServicio:(Servicio*)servicio
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
        self.title = @"Mis Grupos";
        self.servicio = servicio;
        [self createNotification];
    }
    return self;
}

-(void)createNotification{
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(gruposOK:)
                                                 name:SERVICE_GRUPOSDeServicio_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(gruposFailed:)
                                                 name:SERVICE_GRUPOSDeServicio_FAILED
                                               object:nil];
}

- (void)viewDidLoad
{
    [super viewDidLoad];
}

-(void)loadServicios{
    [[SRVBusqueda GetInstance]startsearchGruposDeServicio:self.servicio];
}

-(void)viewDidAppear:(BOOL)animated{
    [super viewDidAppear:animated];
    [self loadServicios];

}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(void)gruposOK:(NSNotification*)notification{
    self.grupos = notification.object;
    [self.tableView reloadData];
}

-(void)gruposFailed:(NSNotification*)notification{
    [[[UIAlertView alloc]initWithTitle:nil message:@"Error al intentar cargar grupos" delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles: nil]show];
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
    return [self.grupos count];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
        cell.textLabel.textAlignment = UITextAlignmentCenter;
    }
    
    Grupo* grupo = [self.grupos objectAtIndex:indexPath.row];
    
    cell.textLabel.text = grupo.Nombre;
    // Configure the cell...
    
    return cell;
}

/*
 // Override to support conditional editing of the table view.
 - (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath
 {
 // Return NO if you do not want the specified item to be editable.
 return YES;
 }
 */

/*
 // Override to support editing the table view.
 - (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath
 {
 if (editingStyle == UITableViewCellEditingStyleDelete) {
 // Delete the row from the data source
 [tableView deleteRowsAtIndexPaths:@[indexPath] withRowAnimation:UITableViewRowAnimationFade];
 }
 else if (editingStyle == UITableViewCellEditingStyleInsert) {
 // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view
 }
 }
 */

/*
 // Override to support rearranging the table view.
 - (void)tableView:(UITableView *)tableView moveRowAtIndexPath:(NSIndexPath *)fromIndexPath toIndexPath:(NSIndexPath *)toIndexPath
 {
 }
 */

/*
 // Override to support conditional rearranging of the table view.
 - (BOOL)tableView:(UITableView *)tableView canMoveRowAtIndexPath:(NSIndexPath *)indexPath
 {
 // Return NO if you do not want the item to be re-orderable.
 return YES;
 }
 */

#pragma mark - Table view delegate


-(NSIndexPath*)tableView:(UITableView *)tableView willSelectRowAtIndexPath:(NSIndexPath *)indexPath{

    return nil;
}




@end
