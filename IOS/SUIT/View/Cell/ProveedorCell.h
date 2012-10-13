//
//  ProveedorCell.h
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Servicio.h"

@interface ProveedorCell : UITableViewCell{
    Servicio* proveedor;
}


@property(nonatomic,retain)Servicio* proveedor;
@end
