//
//  SubCategoriaPikerViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SubCategoriaPikerViewController.h"
#import "CategoriaCell.h"
#import "SRVCategoria.h"

@interface SubCategoriaPikerViewController ()

@end

@implementation SubCategoriaPikerViewController

@synthesize categorizable;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andCategoria:(Categoria*)aCategoria
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        categoria = aCategoria;
        self.title = [NSString stringWithFormat: @"%@",categoria.nombre];
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    [[SRVCategoria GetInstance]searchAllSubCategoriesFrom:categoria];
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
                                                 name:SERVICE_GETSUBCATEGORIES_OK 
                                               object:nil];
}

-(void) getSubCategoriesOK:(NSNotification*)notification{
    if ([categoria isEqual:notification.object]) {
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
    return [categoria.subCategorias count];// [[[SRVCategoria GetInstance]getAllSubCategoriesFrom:categoria]count];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";

    CategoriaCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[CategoriaCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
    }
    
    Categoria* subcategoria = [[[SRVCategoria GetInstance] getAllSubCategoriesFrom:categoria] objectAtIndex:indexPath.row];
    cell.categoria = subcategoria;
    cell.target = self;
    if ([self.categorizable.categorias containsObject:subcategoria]) {
        [tableView selectRowAtIndexPath:indexPath animated:YES scrollPosition:UITableViewScrollPositionNone];
        
    }else {
        [tableView deselectRowAtIndexPath:indexPath animated:YES];
        
    }
    return cell;
}

#pragma mark - Table view delegate

-(void)showSubcategoriaDetail:(Categoria*)aCategoria{
    SubCategoriaPikerViewController* scvc = [[SubCategoriaPikerViewController alloc]initWithNibName:@"SubCategoriaPikerViewController" bundle:nil andCategoria:aCategoria];
    scvc.categorizable = self.categorizable;
    [self.navigationController pushViewController:scvc animated:YES];

}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    Categoria* aCategoria = ((CategoriaCell*)[tableView cellForRowAtIndexPath:indexPath]).categoria;
    [categorizable addCategoriasObject:aCategoria];
}

- (void)tableView:(UITableView *)tableView didDeselectRowAtIndexPath:(NSIndexPath *)indexPath{
    Categoria* aCategoria = ((CategoriaCell*)[tableView cellForRowAtIndexPath:indexPath]).categoria;
    [categorizable removeCategoriasObject:aCategoria];
}

@end
