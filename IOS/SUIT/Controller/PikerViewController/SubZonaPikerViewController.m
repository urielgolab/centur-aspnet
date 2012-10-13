//
//  SubZonaPikerViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SubZonaPikerViewController.h"
#import "ZonaCell.h"
#import "SRVZona.h"

@interface SubZonaPikerViewController ()

@end

@implementation SubZonaPikerViewController

@synthesize zonable;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andZona:(Zona*)aZona
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        zona = aZona;
         self.title = [NSString stringWithFormat: @"%@",zona.nombre];
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

#pragma mark - NOTIFICATION

-(void) createNotification{
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(getSubCategoriesOK:) 
                                                 name: SERVICE_GETSUBCATEGORIES_OK
                                               object:nil];
}

-(void) getSubCategoriesOK:(NSNotification*)notification{
    if ([zona isEqual:notification.object]) {
        [self.tableView reloadData];     
    }
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
    return [[[SRVZona GetInstance]getAllSubZonasFrom:zona]count];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    
    ZonaCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[ZonaCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
    }
    
    Zona* subzona = [[[SRVZona GetInstance] getAllSubZonasFrom:zona] objectAtIndex:indexPath.row];
    cell.zona = subzona;
    if ([self.zonable.zonas containsObject:subzona]) {
        [tableView selectRowAtIndexPath:indexPath animated:YES scrollPosition:UITableViewScrollPositionNone];
        
    }else {
        [tableView deselectRowAtIndexPath:indexPath animated:YES];
        
    }
    return cell;
}

#pragma mark - Table view delegate

-(void)showSubzonaDetail:(Zona *)azona{
    SubZonaPikerViewController* scvc = [[SubZonaPikerViewController alloc]initWithNibName:@"SubZonaPikerViewController" bundle:nil andZona:azona];
    scvc.zonable = self.zonable;
    [self.navigationController pushViewController:scvc animated:YES];
    
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    Zona* azona = ((ZonaCell*)[tableView cellForRowAtIndexPath:indexPath]).zona;
    [zonable addZonasObject:azona];
}

- (void)tableView:(UITableView *)tableView didDeselectRowAtIndexPath:(NSIndexPath *)indexPath{
    Zona* azona = ((ZonaCell*)[tableView cellForRowAtIndexPath:indexPath]).zona;
    [zonable removeZonasObject:azona];
}

@end
