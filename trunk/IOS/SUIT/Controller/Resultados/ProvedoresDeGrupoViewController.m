//
//  ProvedoresDeGrupoViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 10/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "ProvedoresDeGrupoViewController.h"
#import "ProveedorCell.h"

@interface ProvedoresDeGrupoViewController ()

@end

@implementation ProvedoresDeGrupoViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil grupo:(Grupo*)grupo
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.grupo = grupo;
        self.title = @"Servicios del Grupo";
        [self createNotification];
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view.
}

-(void)loadServicios{
    [[SRVBusqueda GetInstance] startsearchServiciosDeGrupo:self.grupo];
}


- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(void)createNotification{
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(servicioGrupoOK:)
                                                 name:SERVICE_SERVICIOSFGrupo_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(servicioGrupoFailed:)
                                                 name:SERVICE_SERVICIOSGrupo_FAILED
                                               object:nil];
    
}


-(void)servicioGrupoOK:(NSNotification*)notification{
    self.serviciosDeGrupo = notification.object;
    [self.tableView reloadData];
}

-(void)servicioGrupoFailed:(NSNotification*)notification{
    [self.navigationController popToRootViewControllerAnimated:YES];
    
    [[[UIAlertView alloc]initWithTitle:nil message:@"No se pudo obtener los Servicios del grupo" delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles: nil]show];
}

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
    return [self.serviciosDeGrupo count];
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    ProveedorCell *cell = (ProveedorCell*)[tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    
    if (!cell) {
        cell = [[ProveedorCell alloc ]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
    }
    cell.proveedor = [self.serviciosDeGrupo objectAtIndex:indexPath.row];
    
    return cell;
}
@end
