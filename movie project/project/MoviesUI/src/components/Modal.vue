<template>
    <div class="modal">
        <div class="modal-content">
            <b-modal>
                <b-form-group>Name
                    <b-form-input id="movieName" type="text" v-model="editMovie.name">
                    </b-form-input>
                </b-form-group>

                <b-form-group>Description
                    <b-form-textarea id="movieDescription" v-model="editMovie.description" rows="3">
                    </b-form-textarea>
                </b-form-group>

                <b-form-group>Release Year
                    <b-form-input id="movieReleaseYear" type="text" v-model="editMovie.releaseYear">
                    </b-form-input>
                </b-form-group>

                <b-form-group>Academy Award
                    <b-form-checkbox id="movieAcademyAward" v-model="editMovie.academyAward">
                    </b-form-checkbox>
                </b-form-group>

                <b-form-group>DirectorId
                    <b-form-input id="movieDirectorId" type="text" v-model="editMovie.directorId">
                    </b-form-input>
                </b-form-group>
            </b-modal>
            
            <!-- <button type="button" class="button-close" v-on:click="close">
                x
            </button> -->


        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                editMovie: {
                    id: 0,
                    name: '',
                    description: '',
                    releaseYear: '',
                    academyAward: '',
                    directorId: ''


                }
            }
        },
        methods: {
            editMovie(movie) {
                this.editMovie.id = movie.id;
                this.editMovie.name = movie.name;
                this.editMovie.description = movie.description;
                this.editMovie.releaseYear = movie.releaseYear;
                this.editMovie.academyAward = movie.academyAward;
                this.editMovie.directorId = movie.directorId;
            },
            
        }
    }
</script>

<style>
.modal {
    position: fixed;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>