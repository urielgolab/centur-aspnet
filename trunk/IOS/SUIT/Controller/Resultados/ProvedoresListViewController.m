//
//  ProvedoresListViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "ProvedoresListViewController.h"
#import "ServiciosResult.h"
#import "ProveedorCell.h"
#import "ProveedorDetailViewController.h"

@interface ProvedoresListViewController ()

@end

@implementation ProvedoresListViewController

@synthesize searchParametre;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.title = @"Proveedores";
    }
    return self;

}

- (void)viewDidLoad
{
    [super viewDidLoad];
    [self loadServicios];
}

-(void)loadServicios{
    [[SRVBusqueda GetInstance] startSearchForProvedores:self.searchParametre delegate:self];    
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

#pragma mark - Result Delegate

-(void)searchDidFinishedOK:(NSObject<SearchResult>*)aresult forSearch:(NSObject<Searchable>*)search{
    result = (ServiciosResult*)aresult;
    [self.tableView reloadData];
}

-(void)searchDidFinishedFailedForSearch:(NSObject<Searchable>*)search whitError:(NSError*)error{
    
}



#pragma mark - Table view data source

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
    return [[result servicios] count];
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    ProveedorCell *cell = (ProveedorCell*)[tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    
    if (!cell) {
        cell = [[ProveedorCell alloc ]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
    }
    cell.proveedor = [result.servicios objectAtIndex:indexPath.row];
    
    return cell;
}

#pragma mark - Table view delegate

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    Servicio *proveedor = ((ProveedorCell*)[tableView cellForRowAtIndexPath:indexPath]).proveedor;
    
    ProveedorDetailViewController * pd = [[ProveedorDetailViewController alloc]initWithNibName:@"ProveedorDetailViewController" bundle:nil andProveedor:proveedor];

    [self.navigationController pushViewController:pd animated:YES];
}

@end
