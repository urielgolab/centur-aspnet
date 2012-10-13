//
//  CategoriaPikerViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "CategoriaPikerViewController.h"
#import "SRVCategoria.h"
#import "CategoriaCell.h"
#import "SubCategoriaPikerViewController.h"

@interface CategoriaPikerViewController ()

@end

@implementation CategoriaPikerViewController
@synthesize categorizable;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        self.title = @"Categorias";
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    [[SRVCategoria GetInstance]searchAllCategories];
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
                                             selector:@selector(getCategoriesOK:) 
                                                 name:SERVICE_GETCATEGORIES_OK 
                                               object:nil];
}

-(void) getCategoriesOK:(NSNotification*)notification{
    [self.tableView reloadData];
}


#pragma mark - Table View

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [[[SRVCategoria GetInstance] getAllCategories]count];
}

// Customize the appearance of table view cells.
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    
    CategoriaCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[CategoriaCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
    }
    
    Categoria* categoria = [[[SRVCategoria GetInstance] getAllCategories] objectAtIndex:indexPath.row];
    cell.target = self;
    cell.categoria = categoria;
    if ([self.categorizable.categorias containsObject:categoria]) {
        [tableView selectRowAtIndexPath:indexPath animated:YES scrollPosition:UITableViewScrollPositionNone];
        
    }else {
        [tableView deselectRowAtIndexPath:indexPath animated:YES];
        
    }
     return cell;
}

-(void)showSubcategoriaDetail:(Categoria*)categoria{
    SubCategoriaPikerViewController* scvc = [[SubCategoriaPikerViewController alloc]initWithNibName:@"SubCategoriaPikerViewController" bundle:nil andCategoria:categoria];
    scvc.categorizable = self.categorizable;
    [self.navigationController pushViewController:scvc animated:YES];
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    Categoria* categoria = ((CategoriaCell*)[tableView cellForRowAtIndexPath:indexPath]).categoria;
    [categorizable addCategoriasObject:categoria];
}

- (void)tableView:(UITableView *)tableView didDeselectRowAtIndexPath:(NSIndexPath *)indexPath{
    Categoria* categoria = ((CategoriaCell*)[tableView cellForRowAtIndexPath:indexPath]).categoria;
    [categorizable removeCategoriasObject:categoria];

}


@end
