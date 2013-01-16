//
//  MasterViewController.m
//  SUIT
//
//  Created by Manuel  Kenar on 02-06-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "MainViewController.h"
#import "BusquedaCategoriaViewController.h"
#import "ProvedoresFavoritosViewController.h"
#import "MisTurnosViewController.h"
#import "MisGruposViewController.h"
@interface MainViewController () {
    NSMutableArray *_objects;
}

@property(nonatomic,retain)UITableView* tableView;

@end

@implementation MainViewController

@synthesize detailViewController = _detailViewController;

@synthesize tableView = _tableView;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.navigationItem.titleView = [[UIImageView alloc]initWithImage:[UIImage imageNamed:@"logotitle"]];

    }
    return self;
}
							
- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    //self.navigationItem.leftBarButtonItem = self.editButtonItem;

    //UIBarButtonItem *addButton = [[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemAdd target:self action:@selector(insertNewObject:)];
    //self.navigationItem.rightBarButtonItem = addButton;
    
    //[self.navigationController.toolbar setItems:items animated:NO];
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

-(void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    [self.tableView reloadData];
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

- (void)insertNewObject:(id)sender
{
    if (!_objects) {
        _objects = [[NSMutableArray alloc] init];
    }
    [_objects insertObject:[NSDate date] atIndex:0];
    NSIndexPath *indexPath = [NSIndexPath indexPathForRow:0 inSection:0];
    [self.tableView insertRowsAtIndexPaths:[NSArray arrayWithObject:indexPath] withRowAnimation:UITableViewRowAnimationAutomatic];
}

#pragma mark - Table View

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    if ([SRVProfile GetInstance].currentUser) {
        return 2;
    }
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    if (section == 0 ) {
        return 1;
    }else if (section == 1) {
        return 3;
    }
    
    return 0;
}

- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section{
    if (section == 0 ) {
        return @"Busquedas";
    }else if (section == 1) {
        return @"Usuario";
    }
    return nil;
}

// Customize the appearance of table view cells.
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSInteger section = indexPath.section;
    NSInteger row = indexPath.row;
    static NSString *CellIdentifier = @"Cell";
    
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
        cell.accessoryType = UITableViewCellAccessoryDisclosureIndicator;
    }
    
    cell.textLabel.textAlignment = UITextAlignmentCenter;
    
    if (section == 0 ) {
        if (row == 0) {
            cell.textLabel.text = @"Buscar Servicios";
        }
         
    }else if (section == 1) {
        if (row == 0) {
            cell.textLabel.text = @"Mis turnos Actuales";
        }else if (row == 1) {
            cell.textLabel.text = @"Favoritos";
        }else if (row == 2){
            cell.textLabel.text = @"Mis Grupos";
        }
    }
    return cell;
}

- (NSIndexPath*)tableView:(UITableView *)tableView willSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSInteger section = indexPath.section;
    NSInteger row = indexPath.row;
    
    if (section == 0) {
        if (row == 0) {
            BusquedaCategoriaViewController* bc = [[BusquedaCategoriaViewController alloc]initWithNibName:@"BusquedaCategoriaViewController" bundle:nil];
            [self.navigationController pushViewController:bc animated:YES];
        }
    }
    
    if (section == 1) {
        if (row == 0) {
            if ([SRVProfile GetInstance].currentUser) {
                MisTurnosViewController* fvc = [[MisTurnosViewController alloc]initWithNibName:@"MisTurnosViewController" bundle:nil];
                [self.navigationController pushViewController:fvc animated:YES];
                
            }

        }
        if (row == 1) {
            if ([SRVProfile GetInstance].currentUser) {
                ProvedoresFavoritosViewController* fvc = [[ProvedoresFavoritosViewController alloc]initWithNibName:@"ProvedoresListViewController" bundle:nil];
                [self.navigationController pushViewController:fvc animated:YES];

            }
        }
        if (row == 2) {
            if ([SRVProfile GetInstance].currentUser) {
                MisGruposViewController* fvc = [[MisGruposViewController alloc]initWithNibName:@"MisGruposViewController" bundle:nil];
                [self.navigationController pushViewController:fvc animated:YES];
                
            }
        }
    }
    return nil;
}

@end
