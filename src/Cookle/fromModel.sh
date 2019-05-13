models=( Admin Frigorifico Historico Ingrediente IngredienteReceita Nota Nutriente NutrienteReceita Passo Plano PreferenciaIngrediente Receita User )
 
export PATH="$PATH:/home/$USER/.dotnet/tools"
 
for m in ${models[@]}
do
    dotnet aspnet-codegenerator controller -name ${m}Controller -m $m -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
done
