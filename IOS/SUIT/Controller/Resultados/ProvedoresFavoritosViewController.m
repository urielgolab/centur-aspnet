    //
//  ProvedoresFavoritosViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 09/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "ProvedoresFavoritosViewController.h"
#import "ProveedorCell.h"

@interface ProvedoresFavoritosViewController ()

@end

@implementation ProvedoresFavoritosViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.title = @"Favoritos";
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
    Usuario* usuario= [SRVProfile GetInstance].currentUser;
    [[SRVBusqueda GetInstance] startsearchFavoritosFor:usuario];
}


- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(void)createNotification{
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(servicioFavoritosOK:)
                                                 name:SERVICE_SERVICIOSFAVORITOS_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(servicioFavoritosFailed:)
                                                 name:SERVICE_SERVICIOSFAVORITOS_FAILED
                                               object:nil];

}


-(void)servicioFavoritosOK:(NSNotification*)notification{
    self.favoritos = notification.object;
    [self.tableView reloadData];
}

-(void)servicioFavoritosFailed:(NSNotification*)notification{
    [self.navigationController popToRootViewControllerAnimated:YES];
    [[[UIAlertView alloc]initWithTitle:nil message:@"No se pudo obtener los Favoritos" delegate:nil cancelButtonTitle:@"Aceptar" otherButtonTitles: nil]show];
}

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
    return [self.favoritos count];
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    ProveedorCell *cell = (ProveedorCell*)[tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    
    if (!cell) {
        cell = [[ProveedorCell alloc ]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
    }
    cell.proveedor = [self.favoritos objectAtIndex:indexPath.row];
    
    return cell;
}

@end
