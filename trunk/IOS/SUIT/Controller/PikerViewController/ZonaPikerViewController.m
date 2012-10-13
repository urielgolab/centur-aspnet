//
//  ZonaPikerViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "ZonaPikerViewController.h"
#import "SRVZona.h"
#import "SubZonaPikerViewController.h"
#import "ZonaCell.h"

@interface ZonaPikerViewController ()

@end

@implementation ZonaPikerViewController

@synthesize zonable;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.title = @"Zonas";
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    [[SRVZona GetInstance]searchAllZonas];
    // Do any additional setup after loading the view from its nib.
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

#pragma mark - NOTIFICATION

-(void) createNotification{
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(getZonasOK:) 
                                                 name:SERVICE_GETZONAS_OK 
                                               object:nil];
}

-(void) getZonasOK:(NSNotification*)notification{
    [self.tableView reloadData];
}


#pragma mark - Table View

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [[[SRVZona GetInstance] getAllZonas]count];
}

// Customize the appearance of table view cells.
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    
    ZonaCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[ZonaCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
    }
    
    Zona* zona = [[[SRVZona GetInstance] getAllZonas] objectAtIndex:indexPath.row];
    cell.target = self;
    cell.zona = zona;
    if ([self.zonable.zonas containsObject:zona]) {
        [tableView selectRowAtIndexPath:indexPath animated:YES scrollPosition:UITableViewScrollPositionNone];
        
    }else {
        [tableView deselectRowAtIndexPath:indexPath animated:YES];
        
    }
    return cell;
}

-(void)showSubzonaDetail:(Zona *)zona{
    SubZonaPikerViewController* scvc = [[SubZonaPikerViewController alloc]initWithNibName:@"SubZonaPikerViewController" bundle:nil andZona:zona];
    scvc.zonable = self.zonable;
    [self.navigationController pushViewController:scvc animated:YES];
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    Zona* zona = ((ZonaCell*)[tableView cellForRowAtIndexPath:indexPath]).zona;
    [zonable addZonasObject:zona];
}

- (void)tableView:(UITableView *)tableView didDeselectRowAtIndexPath:(NSIndexPath *)indexPath{
    Zona* zona = ((ZonaCell*)[tableView cellForRowAtIndexPath:indexPath]).zona;
    [zonable removeZonasObject:zona];
    
}


@end
