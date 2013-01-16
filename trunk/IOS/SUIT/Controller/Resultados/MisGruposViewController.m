//
//  MisGruposViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 10/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "MisGruposViewController.h"
#import "SRVBusqueda.h"
#import "SRVProfile.h"
#import "ProvedoresDeGrupoViewController.h"

@interface MisGruposViewController ()

@end

@implementation MisGruposViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
        self.title = @"Mis Grupos";
        [self createNotification];
    }
    return self;
}

-(void)createNotification{
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(gruposOK:)
                                                 name:SERVICE_GRUPOS_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(gruposFailed:)
                                                 name:SERVICE_GRUPOS_FAILED
                                               object:nil];
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    [self loadServicios];
}

-(void)loadServicios{
    Usuario* usuario = [SRVProfile GetInstance].currentUser;
    [[SRVBusqueda GetInstance] startsearchMisGrupos:usuario];
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
    [self.navigationController popToRootViewControllerAnimated:YES];
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
    Grupo* grupo = [self.grupos objectAtIndex:indexPath.row];
    ProvedoresDeGrupoViewController* pvc = [[ProvedoresDeGrupoViewController alloc]initWithNibName:@"ProvedoresListViewController" bundle:nil grupo:grupo];
    [self.navigationController pushViewController:pvc animated:YES];
    return nil;
}




@end
