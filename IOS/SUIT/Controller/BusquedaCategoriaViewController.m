//
//  BusquedaCategoriaViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "BusquedaCategoriaViewController.h"
#import "CategoriaPikerViewController.h"
#import "ZonaPikerViewController.h"
#import "FechaPikerViewController.h"

#import "CategoriaSearchCell.h"
#import "NombreSearchCell.h"
#import "ZonaSearchCell.h"
#import "BuscarSearchCell.h"
#import "FechaSearchCell.h"

#import "ProvedoresListViewController.h"

typedef enum  {
    CategoriasSearchEntitiesCell,
    ZonaSearchEntitiesCell,
    NombreSearchEntitiesCell,
    FechaSearchEntitiesCell,
    HoraSearchEntitiesCell,
    BuscarSearchEntitiesCell
} UISearchEntitiesCellType;

@interface BusquedaCategoriaViewController ()

@property(nonatomic,retain) UITableView *tableView;

@end


@implementation BusquedaCategoriaViewController

@synthesize tableView= _tableview;

-(id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil{
    
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        searchParametre = [[CategoriaSearchParametre alloc]init];
        searchParametre.delegate = self;
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

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    if (section==0) {
        return 3;
    }
    return 1;
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView 
{
    return 2;
}

- (UITableViewCell*)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath cellForType:(UISearchEntitiesCellType)celltype{
    NSString* CellIdentifier = [NSString stringWithFormat:@"Search:%d",celltype];
    
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];

    switch (celltype) {
        case CategoriasSearchEntitiesCell:
            cell = [[CategoriaSearchCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
            break;
        case ZonaSearchEntitiesCell:
            cell = [[ZonaSearchCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
            break;
            
        case NombreSearchEntitiesCell:
            cell = [[NombreSearchCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
            break;
            
        case FechaSearchEntitiesCell:
            cell = [[FechaSearchCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
            break;
        case BuscarSearchEntitiesCell:
            cell = [[BuscarSearchCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
            
            break;
        default:
            break;
    }
    
    return cell;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell * cell;
    NSInteger row = indexPath.row;
    NSInteger section = indexPath.section;
    
    if (section == 0) {
        if (row == 0) {
            cell =  [self tableView: tableView cellForRowAtIndexPath: indexPath cellForType:CategoriasSearchEntitiesCell];
            ((CategoriaSearchCell*) cell).categorias = searchParametre.categorias;
        }else if (row == 1) {
            cell =  [self tableView: tableView cellForRowAtIndexPath: indexPath cellForType:ZonaSearchEntitiesCell];
            ((ZonaSearchCell*) cell).zonas = searchParametre.zonas;
        }else if(row == 2) {
            cell =  [self tableView: tableView cellForRowAtIndexPath: indexPath cellForType:NombreSearchEntitiesCell]; 
            ((NombreSearchCell*) cell).nombre = searchParametre.nombre;
        }else if (row == 3) {
            cell =  [self tableView: tableView cellForRowAtIndexPath: indexPath cellForType:FechaSearchEntitiesCell];
            ((FechaSearchCell*) cell).fecha = searchParametre.fecha;

        }    
    } else if (section == 1) {
        if (row == 0) {
            cell =  [self tableView: tableView cellForRowAtIndexPath: indexPath cellForType:BuscarSearchEntitiesCell]; 
            ((BuscarSearchCell*) cell).searchParametre = searchParametre;
        }
    }
    
    return cell;
}

#pragma mark - Table view delegate

- (UITableViewCell*)tableView:(UITableView *)tableView willSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSInteger row = indexPath.row;
    NSInteger section = indexPath.section;
    if (section == 0) {
        if (row == 0) {
            CategoriaPikerViewController* cp = [[CategoriaPikerViewController alloc ]initWithNibName:@"CategoriaPikerViewController" bundle:nil];
            cp.categorizable =  searchParametre;
            [self.navigationController pushViewController:cp animated:YES];
        }else if (row == 1) {
            ZonaPikerViewController* zp = [[ZonaPikerViewController alloc ]initWithNibName:@"ZonaPikerViewController" bundle:nil];
            zp.zonable =  searchParametre;
            [self.navigationController pushViewController:zp animated:YES];
        }else if (row == 2) {
            //Nombre
            UIAlertView* alert = [[UIAlertView alloc]initWithTitle:@"Nombre" 
                                                           message:@"Ingrese el nombre que desea buscar" 
                                                          delegate:self 
                                                 cancelButtonTitle:@"Cancelar" 
                                                 otherButtonTitles:@"Aceptar", nil];
            alert.alertViewStyle = UIAlertViewStylePlainTextInput;
            UITextField* textField =  [alert textFieldAtIndex:0];
            textField.text = searchParametre.nombre;
            [alert show];
            
        }else if (row == 3) {
            //Fecha
           FechaPikerViewController * fp = [[FechaPikerViewController alloc ]initWithNibName:@"FechaPikerViewController" bundle:nil];
            fp.fecheable =  searchParametre;
            [self.navigationController pushViewController:fp animated:YES];
        }
    }else if (section == 1) {
        if (row == 0) {
            //BUSCAR
            ProvedoresListViewController * pl =  [[ProvedoresListViewController alloc ]initWithNibName:@"ProvedoresListViewController" bundle:nil];
            pl.searchParametre = searchParametre;
            [self.navigationController pushViewController:pl animated:YES];
        }
    }
    
    return nil;
}

- (void)alertView:(UIAlertView *)alertView didDismissWithButtonIndex:(NSInteger)buttonIndex{
    if ([alertView cancelButtonIndex] == buttonIndex) {
        return;
    }
    UITextField* textField =  [alertView textFieldAtIndex:0];
    searchParametre.nombre = textField.text;
}

-(void)categoriaSearchParametre:(CategoriaSearchParametre*)categoriaSearchParametre{
    [self.tableView reloadData];
}
@end
