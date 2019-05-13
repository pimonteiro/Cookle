#!/bin/bash

models=( Admin Frigorifico Historico Ingrediente IngredienteReceita Nota Nutriente NutrienteReceita Passo Plano PreferenciaIngrediente Receita User )

export PATH="$PATH:/home/$USER/.dotnet/tools"

for m in ${models[@]}
do
    dotnet aspnet-codegenerator controller -name ${m}Controller -m $m -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
done

rm -rf Migrations
cd Data
rm -rf Migrations
cd ..

yes | dotnet ef database drop

dotnet ef migrations add CreateIdentitySchema
dotnet ef database update

mv Migrations Data
