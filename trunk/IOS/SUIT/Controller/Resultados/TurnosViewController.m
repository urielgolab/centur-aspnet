//
//  TurnosViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 05/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "TurnosViewController.h"
#import "SRVBusqueda.h"
#import "SRVProfile.h"

@interface TurnosViewController ()

@end

@implementation TurnosViewController

- (id)initWithStyle:(UITableViewStyle)style
{
    self = [super initWithStyle:style];
    if (self) {
        [self createNotification];
        // Custom initialization
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

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(void)createNotification{
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(reservarOK:)
                                                 name:SERVICE_RESERVARTURNOSSERVICIO_OK
                                               object:nil];
    
    
    [[NSNotificationCenter defaultCenter ]addObserver:self
                                             selector:@selector(reservarFailed:)
                                                 name:SERVICE_RESERVARTURNOSSERVICIO_FAILED
                                               object:nil];
  
}

-(void)reservarOK:(NSNotification*) notification{
    
}


-(void)reservarFailed:(NSNotification*) notification{
    
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
    return [self.turnos count];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleSubtitle reuseIdentifier:CellIdentifier];
    }
    cell.textLabel.text = [[self.turnos objectAtIndex:indexPath.row] Fecha] ;
    cell.textLabel.textAlignment = UITextAlignmentLeft;
    cell.detailTextLabel.textAlignment = UITextAlignmentLeft;
    cell.detailTextLabel.text =  [NSString stringWithFormat:@"%@ - %@",[[self.turnos objectAtIndex:indexPath.row] horaInicio],[[self.turnos objectAtIndex:indexPath.row] horaFin] ];

    // Configure the cell...
    
    return cell;
}


#pragma mark - Table view delegate

-(NSIndexPath*)tableView:(UITableView *)tableView willSelectRowAtIndexPath:(NSIndexPath *)indexPath{
    Turno* turno = [self.turnos objectAtIndex:indexPath.row];
    Usuario* usuario = [SRVProfile GetInstance].currentUser;
    
    if (!usuario) {
        //TODO
        //Levantar la vista de logiarse
        return nil;
    }
    
    [[SRVBusqueda GetInstance] reservarTurno:turno servicio:self.servicio usuario:usuario];
    
    return nil;
}

@end
