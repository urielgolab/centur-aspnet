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
    return 3;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    if (section == 0 ) {
        return 1;
    }else if (section == 1) {
        return 2;
    }
    
    return 0;
}

- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section{
    if (section == 0 ) {
        return @"Busquedas";
    }else if (section == 1) {
        return @"Mis Turnos";
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
            
        }
        if (row == 1) {
            if ([SRVProfile GetInstance].currentUser) {
                ProvedoresFavoritosViewController* fvc = [[ProvedoresFavoritosViewController alloc]initWithNibName:@"ProvedoresListViewController" bundle:nil];
                [self.navigationController pushViewController:fvc animated:YES];

            }
        }
    }
    return nil;
}

@end
